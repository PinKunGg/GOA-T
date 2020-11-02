﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject cam_PlaneStageCam, cam_PlayStageCam, cav_PlaneUI, cav_PlayUI, PauseUI, MainUI, WinUI, LoseUI;
    public GameMode_Controller s_GM_Con;
    public Text BaseHp, BaseHp1;
    public BuildManager buildManager;
    public bool b_PlaneTurn, b_PlayTurn, b_isEsc, b_isWin, b_isLose;
    public float CurrentHp, FullHp;

    private void Awake() //GetComponent
    {
        s_GM_Con = GetComponent<GameMode_Controller>();
    }
    private void Start() //Start Camera In Plane Camera Position
    {
        b_PlaneTurn = true;
        BaseHp.text = CurrentHp + " / " + FullHp;
        BaseHp1.text = CurrentHp + " / " + FullHp;
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && b_isWin == false && b_isLose == false)
        {
            b_isEsc = !b_isEsc;
        }
    }
    private void Update()
    {
        if(CurrentHp <= 0 )
        {
            b_isLose = true;
        }
        if(b_isWin)
        {
            Time.timeScale = 0f;
            buildManager.isPause = true;
            MainUI.SetActive(false);
            WinUI.SetActive(true);
        }
        else if(b_isLose)
        {
            Time.timeScale = 0f;
            buildManager.isPause = true;
            MainUI.SetActive(false);
            LoseUI.SetActive(true);
        }
        if(b_isEsc && b_isWin == false && b_isLose == false)
        {
            Time.timeScale = 0f;
            buildManager.isPause = true;
            PauseUI.SetActive(true);
            MainUI.SetActive(false);
        }
        else if(!b_isEsc && b_isWin == false && b_isLose == false)
        {
            Time.timeScale = 1f;
            buildManager.isPause = false;
            PauseUI.SetActive(false);
            MainUI.SetActive(true);
        }

        if (b_PlayTurn && b_isWin == false && b_isLose == false && b_isEsc == false) //When true Make Camera goto Play Position
        {
            PlayTurnMethod();
        }
        else if(b_PlaneTurn && b_isWin == false && b_isLose == false && b_isEsc == false) //When true Make Camera goto Plane Position
        {
            PlaneTurnMethod();
        }
    }
    public void PlaneTurnMethod() //PlaneTurn
    {
        cam_PlaneStageCam.SetActive(true); //PlaneCamera -Active
        cam_PlayStageCam.SetActive(false); //PlayCamera -DeActive

        cav_PlaneUI.SetActive(true); //Plane UI -Active
        cav_PlayUI.SetActive(false); //Play UI -DeActive
    }
    public void PlayTurnMethod() //PlayTurn
    {
        cam_PlaneStageCam.SetActive(false); //PlaneCamera -DeActive
        cam_PlayStageCam.SetActive(true); //PlayCamera -Active

        cav_PlaneUI.SetActive(false); //Plane UI -DeActive
        cav_PlayUI.SetActive(true); //Play UI -Active
    }

    public void BaseHpCal()
    {
        BaseHp.text = (CurrentHp -= 1f) + " / " + FullHp;
        BaseHp1.text = CurrentHp + " / " + FullHp;
    }
}
