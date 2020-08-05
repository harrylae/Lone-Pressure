using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trout : MonoBehaviour
{
    private Submarine playerClass;

    private GameObject player;
    public GameObject objective1;
    private GameObject objective;

    private bool stopMove;

    private float speed;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerClass = player.GetComponent<Submarine>();
        objective = objective1;

        speed = 100;
    }

    void FixedUpdate()
    {
        if (stopMove == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "Player")
        {
            StartCoroutine("Rest");
        }
    }

    public void Attack()
    {
        objective = player;
    }

    public void AttackOff()
    {
        objective = objective1;
    }

    IEnumerator Rest()
    {
        stopMove = true;
        yield return new WaitForSeconds(2);
        stopMove = false;
        yield return new WaitForEndOfFrame();
    }

}
