using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource[] musics;
    public Vector3[] musicsLoop;
    public Scrollbar scrollbar;
    public int musicNumber;
    private int musicNumberSave; //Guarda el numero de la ultima musica escuchada
    public bool playAwake;

    private float X; //Endica la posicion de inicio al ser reiniciada
    private float Y; //En que tiempo debe reiniciarse
    private float Z; //Si debe o no reiniciarse
    private bool play;

    void Start()
    {
        musicNumberSave = musicNumber;
        if (playAwake == true)
        {
            Replay(musicNumber);
        }
    }
    
    void Update()
    {
        if (play == true)
        {
            if (musics[musicNumber].time >= Y && Z == 1)
            {
                musics[musicNumber].time = X;
            }
        }
    }

    public void Replay(int number)
    {
        musics[musicNumberSave].Stop();
        X = musicsLoop[musicNumber].x;
        Y = musicsLoop[musicNumber].y;
        Z = musicsLoop[musicNumber].z;
        musicNumber = number;
        musicNumberSave = number;
        musics[musicNumber].Play();
        Play();
    }

    private void Play()
    {
        play = true;
    }
    public void Stop()
    {
        play = false;
        musics[musicNumber].Stop();
    }

    public void SoundVolume()
    {
        AudioListener.volume = scrollbar.value;
    }
}
