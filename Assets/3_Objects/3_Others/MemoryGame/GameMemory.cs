using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMemory : MonoBehaviour
{
    public bool deletAll;

    public LoadScene sceneController;
    private int levelLimit;


    private string saveLevel;
    private string saveScore;

    private void Start()
    {
        levelLimit = 100;

        saveLevel = "saveLevel";
        saveScore = "saveScore";
    }

    private void Update()
    {
        if (deletAll == true)
        {
            ToResetComplete();
        }
    }

    public void SaveLevel()
    {
        if (sceneController.levelManual + 1 < levelLimit)
        {
            PlayerPrefs.SetInt(saveLevel, sceneController.levelManual);
        }
    }

    public void SaveScore(int number)
    {
        PlayerPrefs.SetInt(saveScore, number);
    }

    //Resetear Memoria Completa
    private void ToResetComplete()
    {
         PlayerPrefs.DeleteAll();
    }
}
