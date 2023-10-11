using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private int score;

    public int Score
    {
        get
        {
             return score;
        }
        set
        {
            score += value;
        }
    }
    void Start()
    {
        ScoreWrite(0);
        Events.ScoreChange += ScoreWrite;
    }
    private void OnDestroy()
    {
        Events.ScoreChange -= ScoreWrite;
    }
    void ScoreWrite(int increase)
    {
        Score = increase;
        ScoreText.text = "Score : " + score;
    }
}
