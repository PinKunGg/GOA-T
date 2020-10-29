using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode_Controller : MonoBehaviour
{
    //Mode Controller
    public bool b_WaveMode, b_EndlessMode;
    bool b_isNextWave, b_preSpawn;
    public Text txt_ModeTxt;

    //Spawner Controller
    public GameObject g_EnemyPrefab;
    public float f_spawnCount = 3f;
    public Transform g_EnemySpawner;
    public bool b_isSpawn;
    GM s_GM;
    DeckCollect s_DC;
    public static List<Enemy> L_EnemyPrefabSpawn = new List<Enemy>();

    //Timer Controller
    static float sf_TimeFix = 3f;
    float f_ShowTimer;
    bool b_isTimer;
    public Text txt_SpawnTimeTxt, txt_SpawnTimeTxt1;
    public GameObject TimerBG;

    private void Awake() //GetComponent
    {
        s_GM = GetComponent<GM>();
        s_DC = GetComponent<DeckCollect>();
    }
    private void Start()
    {
        //Disable SpawnTimeText
        txt_SpawnTimeTxt.gameObject.SetActive(false);
        txt_SpawnTimeTxt1.gameObject.SetActive(false);
        TimerBG.SetActive(false);

        if(b_EndlessMode) //Work Only In Endless Mode
        {
            b_WaveMode = false;
            EndlessMode();
        }
    }
    private void Update()
    {
        //Run Timer All Time
        SpawnTimer();
        
        //Display Mode on UpperRight Conner
        if(b_WaveMode == true)
        {
            txt_ModeTxt.text = "Mode : Wave";
        }
        else if(b_EndlessMode == true)
        {
            txt_ModeTxt.text = "Mode : Endless";
        }

        //Check ว่ายังมี Enemy ใน Sceen รึเปล่า
        if(b_isSpawn) 
        {
            if(L_EnemyPrefabSpawn.Count == 0f)
            {
                if(b_WaveMode) //Wave Mode
                {
                    s_GM.b_PlayTurn = false;
                    s_GM.b_PlaneTurn = true;
                    s_DC.NewCard();
                    L_EnemyPrefabSpawn.Clear();
                }
                else if(b_EndlessMode) //Endless Mode
                {
                    s_GM.b_PlayTurn = false;
                    s_GM.b_PlaneTurn = true;
                    s_DC.NewCard();
                    L_EnemyPrefabSpawn.Clear();

                    b_isTimer = true;
                    f_ShowTimer = sf_TimeFix;
                    txt_SpawnTimeTxt.gameObject.SetActive(true);
                    txt_SpawnTimeTxt1.gameObject.SetActive(true);
                    TimerBG.SetActive(true);
                }

                b_isSpawn = false;
            }
        }
    }

    void SpawnTimer() //Timer Method
    {
        if (b_isTimer) //Timer Start when true
        {
            if (txt_SpawnTimeTxt.gameObject.activeInHierarchy == true) //Display Timer Txt
            {
                f_ShowTimer -= Time.deltaTime;
                txt_SpawnTimeTxt.text = "Next Wave Spawn in " + Mathf.Round(f_ShowTimer).ToString();
                txt_SpawnTimeTxt1.text = "Next Wave Spawn in " + Mathf.Round(f_ShowTimer).ToString();
            }

            if (f_ShowTimer <= 0) //Do when Timer goto 0
            {
                //Disable Timer Txt
                txt_SpawnTimeTxt.gameObject.SetActive(false);
                txt_SpawnTimeTxt1.gameObject.SetActive(false);
                TimerBG.SetActive(false);

                if (b_WaveMode) //Wave Mode
                {
                    f_spawnCount += 2f;
                    b_isTimer = false;
                    StartCoroutine(WaveSpawn());
                }
                else if(b_EndlessMode)//Eneless Mode
                {
                    sf_TimeFix += 4f;
                    f_spawnCount += 2f;
                    b_isTimer = false;
                    StartCoroutine(EndlessSpawn());
                }
            }
        }
    }

    public void WaveMode() //Start Wave Mode
    {
        sf_TimeFix = 3f;
        f_ShowTimer = sf_TimeFix;
        f_spawnCount = 3f;
        b_isTimer = true;
        b_isNextWave = true;

        txt_SpawnTimeTxt.gameObject.SetActive(true);
        txt_SpawnTimeTxt1.gameObject.SetActive(true);
        TimerBG.SetActive(true);
    }
    public void NextWave() //Start Next Wave
    {
        if (b_isNextWave)
        {
            b_isNextWave = false;
            b_isTimer = true;
            f_ShowTimer = sf_TimeFix;
            txt_SpawnTimeTxt.gameObject.SetActive(true);
            txt_SpawnTimeTxt1.gameObject.SetActive(true);
            TimerBG.SetActive(true);
        }
    }
    public void EndlessMode() //Start Endless Mode
    {
        b_isTimer = true;
        b_isNextWave = false;
        sf_TimeFix = 3f;
        f_ShowTimer = sf_TimeFix;
        f_spawnCount = 3f;
        txt_SpawnTimeTxt.gameObject.SetActive(true);
        txt_SpawnTimeTxt1.gameObject.SetActive(true);
        TimerBG.SetActive(true);
    }

    IEnumerator WaveSpawn() //Spawn Wave
    {
        s_GM.b_PlayTurn = true;
        s_GM.b_PlaneTurn = false;
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < f_spawnCount; i++)
        {
            Instantiate(g_EnemyPrefab, g_EnemySpawner.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);

            if (b_WaveMode == false)
            {
                break;
            }
        }

        b_isSpawn = true;

        if (b_WaveMode == false)
        {
            yield break;
        }
        b_isNextWave = true;
    }

    IEnumerator EndlessSpawn() //Spawn Endless
    {
        s_GM.b_PlayTurn = true;
        s_GM.b_PlaneTurn = false;
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < f_spawnCount; i++)
        {
            Instantiate(g_EnemyPrefab, g_EnemySpawner.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);

            if (b_EndlessMode == false)
            {
                break;
            }
        }

        b_isSpawn = true;

        if (b_EndlessMode == false)
        {
            yield break;
        }
    }
}
