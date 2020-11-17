using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamageCal : MonoBehaviour
{
    public GM s_GM;
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if(other.gameObject.name == "Boss(Clone)" && this.gameObject.name != "FlyEnding")
        {
            print("Boss In Comming!");
            s_GM.BaseBossHpCal();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "GroundEnemy" || other.gameObject.tag == "FlyEnemy" && other.gameObject.name != "Boss(Clone)")
        {
            s_GM.BaseHpCal();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Enemy" && other.gameObject.name != "Boss(Clone)")
        {
            s_GM.BaseHpCal();
            Destroy(other.gameObject);
        }
    }
}
