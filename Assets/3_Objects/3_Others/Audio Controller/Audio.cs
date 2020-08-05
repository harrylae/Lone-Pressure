using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public List<AudioSource> audioList;

    public bool play;

    public int numberAudio = 0;

    void Start()
    {
        PlayAudio(numberAudio);
    }

    public void PlayAudio(int number)
    {
        if (play == true)
        {
            audioList[number].Play();
        }
    }

    public void StopAll()
    {
        foreach (AudioSource a in audioList)
            a.Stop();
    }
}
