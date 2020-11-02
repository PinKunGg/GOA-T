using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    Vector3 target;

    private void Start()
    {
        target = Camera.main.transform.position;
    }

    private void Update()
    {
        transform.LookAt(target);
    }
}
