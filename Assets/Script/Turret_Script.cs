using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Script : MonoBehaviour
{
    private Transform target;

    public Transform RotatePart;

    [Header("Fire & Detect_Range Custom")]
    public float detectRange = 3f;
    public float FireRate = 1f;
    private float FireCountDown = 0f;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        float shotDistance = Mathf.Infinity;
        GameObject nearEenmy = null;

        foreach (GameObject enemy in allEnemy)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shotDistance)
            {
                shotDistance = distanceToEnemy;
                nearEenmy = enemy;
            }
        }

        if (nearEenmy != null && shotDistance <= detectRange)
        {
            target = nearEenmy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        //Look At Target
        Vector3 Face2Target = target.position - transform.position;
        Quaternion Way2Rotate = Quaternion.LookRotation(Face2Target);
        Vector3 JustRotate = Quaternion.Lerp(RotatePart.rotation, Way2Rotate, Time.deltaTime * 10f).eulerAngles;
        RotatePart.rotation = Quaternion.Euler(JustRotate.x, JustRotate.y, 0f);

        if (FireCountDown <= 0f)
        {
            Shoot();
            FireCountDown = 1f / FireRate;
        }

        FireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position,bulletSpawn.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
