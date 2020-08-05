using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChargingScreen : MonoBehaviour {
	public int sceneload;

	void Start(){
		StartCoroutine (LoadNewScene ());
        Time.timeScale = 1f;
    }

	IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds (2);
        sceneload = PlayerPrefs.GetInt("Level");
        AsyncOperation async = SceneManager.LoadSceneAsync (sceneload);
		while (!async.isDone) {
            yield return null;
		}
	}
}
