using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Quiz Questions", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField ]string questionText = "Enter new question text here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string getQuestionText()
    {
        return questionText;
    }

    public string getAnswers(int idx)
    {
        return answers[idx];
    } 

    public int getCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

}
