using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed;

    Transform target;
    int waypointIndex = 0;

    void Start()
    {
        Debug.Log("EnemyScript - Active");

        target = Waypoint.point[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void GetNextWayPoint()
    {
        if(waypointIndex >= Waypoint.point.Length - 1)
        {
            Destroy(this.gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoint.point[waypointIndex];
    }
}
