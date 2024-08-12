using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI scoreBoard;
    [SerializeField] TextMeshProUGUI candyBoard;

    int bestScore;



    public void OnDeadUI(int lastScore, int candyScore)
    {
        if (lastScore > bestScore) 
        {
            bestScore = lastScore;
        }

        bestScoreText.text = ("Best Score: " + bestScore);
        finalScoreText.text = ("Final Score: " + lastScore);
        candyBoard.text = ("Total Candy: " + candyScore);

    }

    public void UpdateScoreBoard(int turns)
    {
        scoreBoard.text = ("Score: " + turns);
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt("int_bestScore", bestScore);
    }

    public void LoadPrefs()
    {
        bestScore = PlayerPrefs.GetInt("int_bestScore", 0);
    }


}
