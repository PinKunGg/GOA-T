using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public GameObject cam_PlaneStageCam, cam_PlayStageCam, cav_PlaneUI, cav_PlayUI;
    public GameMode_Controller s_GM_Con;
    public bool b_PlaneTurn, b_PlayTurn;

    private void Awake() //GetComponent
    {
        s_GM_Con = GetComponent<GameMode_Controller>();
    }
    private void Start() //Start Camera In Plane Camera Position
    {
        b_PlaneTurn = true;
    }
    private void Update()
    {
        if (b_PlayTurn) //When true Make Camera goto Play Position
        {
            PlayTurnMethod();
        }
        else if(b_PlaneTurn) //When true Make Camera goto Plane Position
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
}
