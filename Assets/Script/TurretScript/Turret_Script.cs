﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Script : MonoBehaviour
{
    private Transform trans_target;

    public Transform trans_RotatePart, trans_bulletSpawn;

    [Header("Fire & Detect_Range Custom")]
    public float detectRange = 3f;
    public float FireRate = 1f;
    private float FireCountDown = 0f;

    public GameObject g_bulletPrefab;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy"); //Collect all Enemy
        float shootDistance = Mathf.Infinity;

        GameObject nearEenmy = null;

        foreach (GameObject enemy in allEnemy) //Loop to All Enemy
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); //Checkt distance between All Enemy and this Turret

            if (distanceToEnemy < shootDistance) //if distance less that shootDistance make that Enemy is nearEnemy
            {
                shootDistance = distanceToEnemy;
                nearEenmy = enemy;
            }
        }

        if (nearEenmy != null && shootDistance <= detectRange)
        {
            trans_target = nearEenmy.transform;
        }
        else
        {
            trans_target = null;
        }
    }

    void Update()
    {
        if (trans_target == null)
        {
            return;
        }

        //Look At Target
        Vector3 Face2Target = trans_target.position - transform.position;
        Quaternion Way2Rotate = Quaternion.LookRotation(Face2Target);
        Vector3 JustRotate = Quaternion.Lerp(trans_RotatePart.rotation, Way2Rotate, Time.deltaTime * 10f).eulerAngles;
        trans_RotatePart.rotation = Quaternion.Euler(JustRotate.x, JustRotate.y, 0f);

        if (FireCountDown <= 0f)
        {
            Shoot();
            FireCountDown = 1f / FireRate;
        }

        FireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(g_bulletPrefab, trans_bulletSpawn.position,trans_bulletSpawn.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}