using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_PlayTest : MonoBehaviour
{
    public GameObject PlaneStageCam;
    public GameObject PlayeStageCam;
    public GameObject PlanUI;
    public GameObject PlayUI;
    public bool PlayNPlanToggle = false;
    GameMode_Controller GMCon;

    private void Awake()
    {
        GMCon = GetComponent<GameMode_Controller>();
    }
    void Start()
    {
        StarCam();
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
}
