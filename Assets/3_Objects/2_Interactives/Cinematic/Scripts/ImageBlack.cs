using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBlack : MonoBehaviour
{
    public GameObject body1;
    public Image body2;
    private float color;

    void Start()
    {
        body1.SetActive(true);
        color = 0.01f;
    }

    void Update()
    {
        if (body2.GetComponent<Image>().color.a > 0)
        {
            body2.GetComponent<Image>().color -= new Color(0f, 0f, 0f, color);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
