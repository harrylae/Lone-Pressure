using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EllVision : MonoBehaviour
{
    public GameObject ell;
    private bool active;
    private float counter;

    private void FixedUpdate()
    {
        if(active == true)
        {
            if(counter >= 3)
            {
                Destroy(gameObject);
            }
            else
            {
                counter += 0.02f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Collider2D>().tag == "Player")
        {
            active = true;
            ell.SetActive(true);
        }
    }
}
