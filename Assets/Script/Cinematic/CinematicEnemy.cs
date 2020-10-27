using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    bool isRot = false;

    private void Update()
    {
        Vector3 dir = target.position - transform.position;

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            transform.rotation = Quaternion.Euler(0f, -35f , 0f);
        }
        else
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
    }
}
