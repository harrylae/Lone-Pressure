using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScenary : MonoBehaviour
{
    public Sprite image1;
    public BodyImageScenary bodyImage1;
    public Sprite image2;
    public BodyImageScenary bodyImage2;
    public Sprite image3;
    public BodyImageScenary bodyImage3;
    
    public void UpdateImages()
    {
        bodyImage1.spriteBody.sprite = image1;
        bodyImage2.spriteBody.sprite = image2;
        bodyImage3.spriteBody.sprite = image3;
    }
}
