using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatEll : MonoBehaviour
{
    public LevelController levelController;
    public Submarine submarine;
    public Animator anim;
    public Transform scenary;
    public GameObject eli;

    private List<float> tracks;

    private bool active;
    private bool go;

    private int attackAction;
    private float attackCounter;
    public float attackTime;

    public int rocksNumber;
    public int elisNumber;

    private void Start()
    {
        Active();

        tracks = new List<float>();
        tracks.Add(0);
        tracks.Add(122f);
        tracks.Add(0);
        tracks.Add(-122f);
    }

    private void Active()
    {
        active = true;
    }
    public void Desactive()
    {
        active = false;
    }

    void FixedUpdate()
    {
        if (go == true)
        {
            if (attackCounter >= attackTime)
            {
                attackCounter = 0;
                AttackAction();
                if (attackAction == 1)
                {
                    anim.SetBool("Attack1", false);
                    anim.SetBool("Attack2", false);
                    anim.SetBool("Attack3", false);
                    anim.SetBool("CallElis", false);
                    Attack();
                }
                if (attackAction == 2)
                {
                    anim.SetBool("Attack1", false);
                    anim.SetBool("Attack2", false);
                    anim.SetBool("Attack3", false);
                    CallElis();
                }
            }
            else
            {
                attackCounter += 0.02f;
            }
        }
    }

    public void Go()
    {
        go = true;
        anim.SetBool("Go", true);
    }
    public void Sleep()
    {
        go = false;
        anim.SetBool("Go", false);
    }

    private void AttackAction()
    {
       attackAction = Random.Range(1, 4);
    }

    private void Attack()
    {
        if(submarine.objectiveActual == 1)
        {
            Attack1();
        }
        if (submarine.objectiveActual == 2)
        {
            Attack2();
        }
        if (submarine.objectiveActual == 3)
        {
            Attack3();
        }
    }
    private void Attack1()
    {
        anim.SetBool("Attack1", true);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
    }
    private void Attack2()
    {
        anim.SetBool("Attack2", true);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack3", false);
    }
    private void Attack3()
    {
        anim.SetBool("Attack3", true);
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
    }

    public void CallElis()
    {
        anim.SetBool("CallElis", true);
        float Y = 0;
        int numberRandom = Random.Range(elisNumber - 2, elisNumber + 1);
        for (int x = 0; x < elisNumber; x++)
        {
            Y = tracks[Random.Range(0, 4)];
            Vector2 position = new Vector2(transform.localPosition.x + 450, transform.position.y + Y);
            Instantiate(eli, position, Quaternion.identity, scenary);
        }
    }
}
