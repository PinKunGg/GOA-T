using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPreview : MonoBehaviour
{
    private void Update()
    {
        this.transform.Rotate(0,10f * Time.deltaTime,0f);   
    }
}
