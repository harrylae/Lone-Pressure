using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public LoadScene controllerScene;
    public GameObject continueButton;
    public GameObject newGame1;
    public GameObject newGame2;
    public int level;

    private void Start()
    {
        level = PlayerPrefs.GetInt("saveLevel");
        if(level >= 2)
        {
            continueButton.SetActive(true);
            newGame1.SetActive(false);
            newGame2.SetActive(true);

        }
    }

    public void Continue()
    {
        controllerScene.LoadLevelManual(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
