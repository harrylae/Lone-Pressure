using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public GameObject objective;

    void Update()
    {
        transform.LookAt(objective.transform.position);
    }
}
