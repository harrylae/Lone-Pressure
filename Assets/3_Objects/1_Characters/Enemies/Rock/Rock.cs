using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Animator anim;
    private int value;

    void Start()
    {
        anim = GetComponent<Animator>();

        value = Random.Range(0, 4);
        if (value == 1)
        {
            anim.SetFloat("Opciones", 1);
        }
        if (value == 2)
        {

            anim.SetFloat("Opciones", 2);
        }
        if (value == 3)
        {

            anim.SetFloat("Opciones", 3);
        }
    }
}
