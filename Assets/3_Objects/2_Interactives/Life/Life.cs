using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private int lifesAdd;
    private Submarine player;
    private GameObject playerGO;

    private void Start()
    {
        lifesAdd = 3;

        playerGO = GameObject.FindWithTag("Player");
        player = playerGO.GetComponent<Submarine>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "Player")
        {
            AddLifes();
        }
    }

    private void AddLifes()
    {
        Destroy(gameObject);
        player.AddLifes(lifesAdd);
    }
}
