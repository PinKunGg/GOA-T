using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;

    Transform target;
    int waypointIndex = 0;

    float EnemyHp = 5f;

    static float num = 0f;

    void Start()
    {
        target = Waypoint.point[0];
    }

    private void OnEnable()
    {
        num++;
        this.gameObject.name = "Enemy_" + num;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        if(EnemyHp <= 0)
        {
            Destroy(gameObject);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PBullet")
        {
            EnemyHp -= 1f;
        }
    }
}
