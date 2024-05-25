using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalscore;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    public void showFinalScore()
    {
        finalscore.text = "Congratulation!\nYou Scored: " + scoreKeeper.calculateScore() + "%";
    }



}
