using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDamageCal : MonoBehaviour
{
    public GM s_GM;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            s_GM.BaseHpCal();
            Destroy(other.gameObject);
        }
    }
}
