﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]    
    [SerializeField] TextMeshProUGUI questionText;
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correcAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Sprites")]
    [SerializeField] Sprite defaulAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image imageTimer;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;
    public bool isComplete;

  

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
        //getNextQuestion();
    }

    private void Update()
    {
        imageTimer.fillAmount = timer.fillFraction;

        if(timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }


            hasAnsweredEarly = false;
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            displayAnswer(-1);
            setButtonState(false);
        }
    }

    private void displayQuestion()
    {
        questionText.text = currentQuestion.getQuestionText();
        showAnswer();

    }
    private void showAnswer()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswers(i);
        }
    }

    public void displayAnswer(int index)
    {
        Image imageButton;
        if (index == currentQuestion.getCorrectAnswerIndex())
        {
            questionText.text = "Chính xác!";
            imageButton = answerButtons[index].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
            scoreKeeper.incrementCorrectAnswer();
        }
        else if(index == -1)
        {
            correcAnswerIndex = currentQuestion.getCorrectAnswerIndex();
            string correcAnswer = currentQuestion.getAnswers(correcAnswerIndex);
            questionText.text = "Hết giờ, Câu trả lời chính xác là\n" + correcAnswer;
            imageButton = answerButtons[correcAnswerIndex].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
        }
        else
        {
            correcAnswerIndex = currentQuestion.getCorrectAnswerIndex();
            string correcAnswer = currentQuestion.getAnswers(correcAnswerIndex);
            questionText.text = "Sai, Câu trả lời chính xác là\n" + correcAnswer;
            imageButton = answerButtons[correcAnswerIndex].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
        }

    }   

    public void onAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        displayAnswer(index);
        setButtonState(false);
        timer.cancelTimer();

        scoreText.text =  "score: " + scoreKeeper.calculateScore() + "%";

        if(progressBar.value == progressBar.maxValue)
        {
            isComplete = true;
        }
    }

    void setButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
            
        }
    }

    private void getNextQuestion()
    {
        if (questions.Count > 0)
        {
            setButtonState(true);
            resetButton();
            getRandomQuestion();
            displayQuestion();

            progressBar.value++;
            scoreKeeper.incrementQuestionsSeen();
        }
    }

    void getRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void resetButton()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image imageButton = answerButtons[i].GetComponent<Image>();
            imageButton.sprite = defaulAnswerSprite;
        }
    }
}
