using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

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

    void Update()
    {
        
    }
}
