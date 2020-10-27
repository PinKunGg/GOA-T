using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CinematicTurret : MonoBehaviour
{
    private Transform target;
    public Transform RotatePart;
    public Renderer[] rend;
    public Animator anima;

    public float detectRange = 3f;
    public float effect = 2f;
    private void Awake()
    {
        anima.SetBool("EffectIn", false);
        anima.SetTrigger("ForceOut");
    }
    void Start()
    {
        anima = GetComponent<Animator>();
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
        rend[0].material.SetFloat("Vector1_DABC1D58", effect);
        rend[1].material.SetFloat("Vector1_DABC1D58", effect);
        rend[2].material.SetFloat("Vector1_DABC1D58", effect);
        rend[3].material.SetFloat("Vector1_DABC1D58", effect);
        rend[4].material.SetFloat("Vector1_DABC1D58", effect);
        rend[5].material.SetFloat("Vector1_DABC1D58", effect);
        rend[6].material.SetFloat("Vector1_DABC1D58", effect);

        if (target == null)
        {
            return;
        }

        //Look At Target
        Vector3 Face2Target = target.position - transform.position;
        Quaternion Way2Rotate = Quaternion.LookRotation(Face2Target);
        Vector3 JustRotate = Quaternion.Lerp(RotatePart.rotation, Way2Rotate, Time.deltaTime * 10f).eulerAngles;
        RotatePart.rotation = Quaternion.Euler(JustRotate.x, JustRotate.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
