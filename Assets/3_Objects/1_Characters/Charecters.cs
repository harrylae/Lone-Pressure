using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Charecters : MonoBehaviour
{
    private GameObject player;
    public GameObject body;
    private float dist;
    private float distLimet = 6;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {

        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < distLimet)
        {
            if (body.activeSelf == false)
            {
                body.SetActive(true);
            }
        }
        else
        {
            if (body.activeSelf == true)
            {
                body.SetActive(false);
            }
        }
    }
}
