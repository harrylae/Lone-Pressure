using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Submarine : MonoBehaviour
{
    //public bool suicidarse;
    public DeadMenu deadmenu;
    private Rigidbody2D rb2d;

    public SubmarineBody body;
    public GameObject bodyDead;
    
    public AudioSource soundIdle;
    public AudioSource soundMove;
    public AudioSource soundHurt;
    public AudioSource soundDead;

    public Sprite body1;
    public Sprite body2;
    public Sprite body3;

    private int lifes;
    private bool invulnerable;
    private float darknessDamaged = 0.2f;

    public float speed;

    private int numberGuard;
    public Track track;
    public int objectiveActual;
    public GameObject objective;
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;

    private void Start()
    {
        lifes = 3;
        rb2d = GetComponent<Rigidbody2D>();
        numberGuard = 2;
    }

    private void FixedUpdate()
    {
       // if(suicidarse==true){ Dead();}
        if (lifes >= 1)
        {
            if (track.TrackNumber == 1)
            {
                objectiveActual = 1;
                   objective = objective1;
            }
            if (track.TrackNumber == 2)
            {
                objectiveActual = 2;
                objective = objective2;
            }
            if (track.TrackNumber == 3)
            {
                objectiveActual = 3;
                objective = objective3;
            }

            if(numberGuard != track.TrackNumber)
            {
                soundMove.Play();
                numberGuard = track.TrackNumber;
            }
            transform.position = Vector2.MoveTowards(transform.position, objective.transform.position, speed * Time.deltaTime);
        }
        else
        {
            Dead();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (lifes >= 1)
        {
            if (other.GetComponent<Collider2D>().tag == "Enemy")
            {
                LostLife();
            }
        }
    }

    private void LostLife()
    {
        if (invulnerable == false)
        {
            lifes -= 1;
            UpdateBody();
            soundHurt.Play();
            StartCoroutine("Invulnerable");
        }
    }
    private void UpdateBody()
    {
        if (lifes >= 1)
        {
            if (lifes == 3)
            {
                body.spriteBody.sprite = body1;
            }
            if (lifes == 2)
            {
                body.spriteBody.sprite = body2;
            }
            if (lifes == 1)
            {
                body.spriteBody.sprite = body3;
            }
        }
    }

    IEnumerator Invulnerable()
    {
        invulnerable = true;
        body.GetComponent<Image>().color = new Color(darknessDamaged, darknessDamaged, darknessDamaged, 1f);
        yield return new WaitForSeconds(2);
        body.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        invulnerable = false;
        yield return new WaitForEndOfFrame();
    }

    public void AddLifes(int number)
    {
        lifes = number;
        UpdateBody();
    }

    private void Dead()
    {

        body.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0);
        bodyDead.SetActive(true);
        soundIdle.Stop();
        soundMove.Stop();
        soundDead.Play();
        deadmenu.Active();
    }

}
