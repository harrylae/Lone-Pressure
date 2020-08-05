using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameMemory gameMemory;

    public bool modeInfinit;
    private bool active;
    public Text text;
    public int score;
    private int scoreAdd;
    private float scoreCounter;

    public Text text2;
    private int scoreSave;

    private void Start()
    {
        scoreAdd = 1;
        scoreSave= PlayerPrefs.GetInt("saveScore");
        text2.text = scoreSave.ToString();
        Active();
    }
    void Update()
    {
        if (active == true && modeInfinit == true)
        {
            text.text = score.ToString(); //señal texto
            if (scoreCounter >= 1)
            {
                scoreCounter = 0;
                score += scoreAdd;
            }
            else
            {
                scoreCounter += 0.02f;
            }
        }
    }

    public void AddScore(int number)
    {
        score += number;
    }

    public void Active()
    {
        active = true;
    }
    public void Desactive()
    {
        active = false;
    }

    public void SaveScore()
    {
        int scoreGuardado= PlayerPrefs.GetInt("saveScore");
        if (modeInfinit == true && score >= scoreGuardado)
        {
            gameMemory.SaveScore(score);
        }
    }
}
