using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Demo : MonoBehaviour
{
    public GameObject PlaneStageCam;
    public GameObject PlayeStageCam;
    public GameObject PlanUI;
    public GameObject PlayUI;
    public GameObject TestUI;
    bool isTestUI = true;

    private void Start()
    {
        StarCam();
    }
    private void LateUpdate()
    {

    }
    private void Update()
    {

    }

    void StarCam()
    {
        PlaneStageCam.SetActive(true);
        PlayeStageCam.SetActive(false);
        PlanUI.SetActive(true);
        PlayUI.SetActive(false);
    }
    public void PlaneTurn()
    {
        PlaneStageCam.SetActive(true);
        PlayeStageCam.SetActive(false);
        PlanUI.SetActive(true);
        PlayUI.SetActive(false);
    }
    public void PlayTurn()
    {
        PlaneStageCam.SetActive(false);
        PlayeStageCam.SetActive(true);
        PlanUI.SetActive(false);
        PlayUI.SetActive(true);
    }
    public void TestUIBut()
    {
        isTestUI = !isTestUI;
        TestUI.SetActive(isTestUI);
    }
    public void MenuBut()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
