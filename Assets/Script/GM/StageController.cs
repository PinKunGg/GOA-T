using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public GameMode_Controller s_GameMode_Con;
    bool isWaveStart = false;

    public void StartPlayTurn_Button()
    {
        if(isWaveStart == false)
        {
            isWaveStart = true;
            s_GameMode_Con.WaveMode();
        }
        else
        {
            s_GameMode_Con.NextWave();
        }
    }
}
