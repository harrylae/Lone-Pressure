using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public MusicController musicController;
    private Score score;
    private GameObject scoreGO;
    public GameObject body;
    public GameObject buttonPause;
    public AudioSource[] sounds;
    public Image button_sound;
    private bool pause;

    private void Start()
    {
        scoreGO = GameObject.FindWithTag("Score");
        score = scoreGO.GetComponent<Score>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        score.Desactive();
        musicController.Replay(1);
        pause = true;
        Time.timeScale =0f;
        body.SetActive(true);
        buttonPause.SetActive(false);
        sounds[0].Play();
    }

    public void Resume()
    {
        score.Active();
        musicController.Replay(0);
        pause = false;
        Time.timeScale = 1f;
        body.SetActive(false);
        buttonPause.SetActive(true);
        sounds[1].Play();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene(1);
    }
}
