using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "Cleaner")
        {
            Destroy(gameObject);
        }
        if (other.GetComponent<Collider2D>().tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
