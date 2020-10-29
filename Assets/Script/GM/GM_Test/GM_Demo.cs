using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_Demo : MonoBehaviour
{
    // ------- NOT USE SCRIPT -------

    /**
    public GameObject PlaneStageCam;
    public GameObject PlayeStageCam;
    public GameObject PlanUI;
    public GameObject PlayUI;
    public GameObject TestUI;
    bool isTestUI = true;
    public bool PlayNPlanToggle = false;

    GameMode_Controller GMCon;

    private void Start()
    {
        GMCon = GetComponent<GameMode_Controller>();
        StarCam();
    }
    private void LateUpdate()
    {

    }
    private void Update()
    {
        if (PlayNPlanToggle)
        {
            PlaneStageCam.SetActive(false);
            PlayeStageCam.SetActive(true);
            PlanUI.SetActive(false);
            PlayUI.SetActive(true);
        }
        else
        {
            PlaneStageCam.SetActive(true);
            PlayeStageCam.SetActive(false);
            PlanUI.SetActive(true);
            PlayUI.SetActive(false);
        }
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
        if (GMCon.inAction == false)
        {
            PlayNPlanToggle = false;
            PlaneStageCam.SetActive(true);
            PlayeStageCam.SetActive(false);
            PlanUI.SetActive(true);
            PlayUI.SetActive(false);
        }
    }
    public void PlayTurn()
    {
        if(GMCon.inAction == false)
        {
            PlayNPlanToggle = true;
            PlaneStageCam.SetActive(false);
            PlayeStageCam.SetActive(true);
            PlanUI.SetActive(false);
            PlayUI.SetActive(true);
        }
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
    **/
}
