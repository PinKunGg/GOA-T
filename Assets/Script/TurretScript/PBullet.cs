using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
    Rigidbody rb;
    Vector3 SpawnPos;

    float speed = 20f;
    float bulletFlyDistance = 20f;

    public GameObject FireFX;
    public float Damage;

    void Start()
    {
        SpawnPos = this.transform.position;
        rb = this.GetComponent<Rigidbody>();

        //GameObject effectIns = (GameObject)Instantiate(FireFX, transform.position, transform.rotation);
        //Destroy(effectIns, 1.5f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

        if (Vector3.Distance(this.transform.position, SpawnPos) > bulletFlyDistance)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            try
            {
                other.GetComponent<Enemy>().HpCal(Damage);
            }
            catch
            {
                other.GetComponent<FlyEnemy>().HpCal(Damage);
            }
            Destroy(gameObject);
        }
        if(other.CompareTag("GroundEnemy"))
        {
            other.GetComponent<Enemy>().HpCal(Damage);
            Destroy(gameObject);
        }
        else if(other.CompareTag("FlyEnemy"))
        {
            other.GetComponent<FlyEnemy>().HpCal(Damage);
            Destroy(gameObject);
        }
    }
}
