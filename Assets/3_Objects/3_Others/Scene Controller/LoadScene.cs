using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    private int initialScenesIgnored; //Las escenas como Menu y pantalla de carga; ocupan un lugar en la lista de escenas (Menu =0 y pan.carg =1). Especificamente, ocupan los primeros lugares. Haciendo que el nivel 1, no sea nivel 1, si no mas bien "nivel 2". Para evitar confusiones al momento de selecionar niveles; se realiza este atrivuto
    public int levelManual; //Seleccion previa del nivel para el metodo "LoadLevel".
    private int sceneChargingScreen;
    private int saveLevel;

    private void Start()
    {
        initialScenesIgnored = 3;
        sceneChargingScreen = 1;
    }

    //Este metodo selecciona su escena al empezar el juego; y no requiere intereaccion obligada del jugador para ejecutarse.
    public void LoadLevel()
    {
        levelManual += initialScenesIgnored;
        saveLevel = levelManual;
        SceneManager.LoadScene(sceneChargingScreen);
        SaveLevel();
    }
    
    //Este metodo permite seleccionar el nivel por un "Button" durante el juego (ideal para los menu o botones), por ende el jugador puede elegir.
    public void LoadLevelManual(int levelManual)
    {
        levelManual += initialScenesIgnored;
        saveLevel = levelManual;
		SceneManager.LoadScene(sceneChargingScreen);
        SaveLevel();
    }

    //Carga al menu principal
    public void LoadMenu()
    {
        saveLevel = 0;
        SceneManager.LoadScene(sceneChargingScreen);
        SaveLevel();
    }

    private void SaveLevel()
    {
        PlayerPrefs.SetInt("Level", saveLevel);
    }

}
