﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float f_enemySpeed = 3f;

    Transform trans_target; //Waypoint to go
    int i_waypointIndex = 0;
    float f_EnemyHp = 5f;
    static float f_index = 0f; //idex of Enemy Prefab (when Debug)

    void Start() //Set WayPoint to 0
    {
        trans_target = Waypoint.point[0];
    }

    private void OnEnable() //Make Enemy Add to GameMode_Controller List to Check if it on Sceen yet?
    {
        f_index++;
        this.gameObject.name = "Enemy_" + f_index;
        GameMode_Controller.L_EnemyPrefabSpawn.Add(this);
    }

    private void OnDestroy() //Remove themself in GameMode_Controller List when Destroy
    {
        GameMode_Controller.L_EnemyPrefabSpawn.Remove(this);
    }

    void Update()
    {
        Vector3 dir = trans_target.position - transform.position; //Make Path from themself to current WayPoint

        transform.Translate(dir.normalized * f_enemySpeed * Time.deltaTime, Space.World); //Make Enemy Walk

        if(Vector3.Distance(transform.position, trans_target.position) <= 0.2f) //Check distance between themself and current WayPoint
        {
            GetNextWayPoint();
        }

        if(f_EnemyHp <= 0) //when Hp = 0 Destroy
        {
            Destroy(gameObject);
        }
    }

    void GetNextWayPoint()
    {
        if(i_waypointIndex >= Waypoint.point.Length - 1) //Check if there are any WayPoint left to go, if not Destroy themself
        {
            Destroy(this.gameObject);
            return;
        }

        i_waypointIndex++;
        trans_target = Waypoint.point[i_waypointIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PBullet")
        {
            f_EnemyHp -= 1f;
        }
    }
}