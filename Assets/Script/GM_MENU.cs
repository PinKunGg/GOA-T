using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GM_MENU : MonoBehaviour
{
    public CinemachineFreeLook CF;
    void Start()
    {
        
    }

    void Update()
    {
        CF.m_XAxis.Value += 3f * Time.deltaTime;
    }

    public void PlayBut()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void ExitBut()
    {
        Application.Quit();
    }
}
