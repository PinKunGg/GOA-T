using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public static Transform[] point;

    void Awake()
    {
        point = new Transform[transform.childCount];
        for (int i = 0; i < point.Length; i++)
        {
            point[i] = transform.GetChild(i);
        }
    }
}
