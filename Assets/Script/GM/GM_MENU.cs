using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GM_MENU : MonoBehaviour
{
    public CinemachineFreeLook CF;
    void Update()
    {
        CF.m_XAxis.Value += 3f * Time.deltaTime;
    }
}
