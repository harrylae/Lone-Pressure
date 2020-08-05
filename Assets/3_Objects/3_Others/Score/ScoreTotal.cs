using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTotal : MonoBehaviour
{
    public Text text;
    private int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("saveScore");
        text.text = score.ToString();
    }
}
