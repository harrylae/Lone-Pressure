using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cinematic : MonoBehaviour
{
    public List<Sprite> imagens;
    public CinematicBody body1;
    public Image body2;
    public GameObject buttons;
    public MusicController musicController;
    public LoadScene loadScene;
    private int imagenNumber;

    private float counter;
    private float color;
    private bool active;

    private void Start()
    {
        musicController.Replay(3);
        color = 0.01f;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (active == false)
        {
            if (body2.GetComponent<Image>().color.a < 1)
            {
                body2.GetComponent<Image>().color += new Color(0f, 0f, 0f, color);
            }
            else
            {
                if (body1.GetComponent<Image>().color.r < 1)
                {
                    body1.spriteBody.sprite = imagens[0];
                    body1.GetComponent<Image>().color += new Color(color, color, color, 1);
                }
                else
                {
                    buttons.SetActive(true);
                    body1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                    CinematicOpen();
                }
            }
        }
    }

    private void CinematicOpen()
    {
        active = true;
        body1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }

    public void NextImagen()
    {
        if (imagenNumber < imagens.Capacity - 1)
        {
            imagenNumber += 1;
            body1.spriteBody.sprite = imagens[imagenNumber];
        }
        else
        {
            LoadScene();
        }
    }
    public void PrevImagen()
    {
        if (imagenNumber > 0)
        {
            imagenNumber -= 1;
            body1.spriteBody.sprite = imagens[imagenNumber];
        }
    }

    private void LoadScene()
    {
        loadScene.LoadLevel();
    }
}
