using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject body;
    public MusicController musicController;
    public Score score;
    private GameObject scoreGO;
    public int levelActual;
    public bool ModeInfinit;

    public GameObject scoreTotal;
    public Text text;

    private void Start()
    {
        scoreGO = GameObject.FindWithTag("Score");
        score = scoreGO.GetComponent<Score>();
    }

    public void Active()
    {
        score.Desactive();
        score.SaveScore();
        musicController.Replay(2);
        body.SetActive(true);
        Time.timeScale = 0f;
        if (ModeInfinit == true)
        {
            scoreTotal.SetActive(true);
            text.text = score.score.ToString();
        }
    }

    public void LevelReplay()
    {
        SceneManager.LoadScene(levelActual + 3);
        Time.timeScale = 1f;
    }
}
