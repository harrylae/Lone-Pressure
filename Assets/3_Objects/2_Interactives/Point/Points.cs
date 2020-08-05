using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    private Score score;
    private GameObject scoreGO;
    private int scoreAdd;

    private void Start()
    {
        scoreAdd = 20;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "Player")
        {
            AddPoints();
        }
    }

    private void AddPoints()
    {
        scoreGO = GameObject.FindWithTag("Score");
        score = scoreGO.GetComponent<Score>();
        score.AddScore(scoreAdd);
        Destroy(gameObject);
    }
   
}
