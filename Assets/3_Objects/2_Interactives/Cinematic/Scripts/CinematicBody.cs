using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicBody : MonoBehaviour
{
    public Image spriteBody;

    private void Start()
    {
        spriteBody = GetComponent<Image>();
    }

}
