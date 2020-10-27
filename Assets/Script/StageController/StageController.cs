using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameMode_Controller GameMode_Con;
    public GM_PlayTest GM;

    bool isWAveStart = false;

    public void StartPlayTurn_Button()
    {
        if(isWAveStart == false)
        {
            isWAveStart = true;
            GameMode_Con.WaveMode();
        }
        else
        {
            GameMode_Con.NextWave();
        }
        
        GM.PlayTurn();
    }
}
