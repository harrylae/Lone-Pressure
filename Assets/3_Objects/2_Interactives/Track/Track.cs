using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Track : MonoBehaviour
{
    public int TrackNumber;

    private void Start()
    {
        TrackNumber = 2;
    }

    public void ChooseTrack(int number)
    {
        TrackNumber = number;
    }

}
