using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    float timerValue;

    public bool loadNextQuestion ;
    public bool isAnsweringQuestion;
    public float fillFraction;

    void Update()
    {
        updateTimer();
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;
            
        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
        }    
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }   
            else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
    }

    public void cancelTimer()
    {
        timerValue = 0;
    }
}
