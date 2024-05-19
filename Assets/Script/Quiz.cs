using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;
    int correcAnswerIndex;
    [SerializeField] Sprite defaulAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;


    void Start()
    {
        getNextQuestion();
        // displayQuestion();
        //setButtonState(true);
    }
    private void displayQuestion()
    {
        questionText.text = question.getQuestionText();
        setQuestion();

    }
    private void setQuestion()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.getAnswers(i);
        }
    }

    public void onAnswerSelected(int index)
    {
        Image imageButton;
        if (index == question.getCorrectAnswerIndex())
        {
            questionText.text = "Chính xác!";
            imageButton = answerButtons[index].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
        }
        else
        {
            correcAnswerIndex = question.getCorrectAnswerIndex();
            string correcAnswer = question.getAnswers(correcAnswerIndex);
            questionText.text = "Sai, Câu trả lời chính xác là\n" + correcAnswer;
            imageButton = answerButtons[correcAnswerIndex].GetComponent<Image>();
            imageButton.sprite = correctAnswerSprite;
        }
        setButtonState(false);
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
        setButtonState(true);
        resetButton();
        displayQuestion();
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
