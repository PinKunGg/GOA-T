using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode_Controller : MonoBehaviour
{
    [Header("Mode")]
    public bool WaveNEndlessToggle = true;
    /*
     * WaveNEndless = true -> Wave
     * WaveNEndless = false -> Endless
     */
    bool isNextWave = false;
    bool preSpawn = false;
    public bool inAction = false;
    public Text ModeTxt;

    [Header("Spawner")]
    public GameObject EnemyPrefab;
    GameObject EnemySpawner;
    public float spawnCount = 3f;
    GM_PlayTest s_GMPlayTest;
    public DeckCollect DC;

    [Header("Timer")]
    static float TimeFix = 3f;
    float ShowTimer;
    bool isTimer = false;
    public Text SpawnTimeTxt, SpawnTimeTxt1;

    void Start()
    {
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
        s_GMPlayTest = GameObject.Find("GM_PlayTest").GetComponent<GM_PlayTest>();

        SpawnTimeTxt.gameObject.SetActive(false);
        SpawnTimeTxt1.gameObject.SetActive(false);

        if(WaveNEndlessToggle == false)
        {
            EndlessMode();
        }
    }
    void Update()
    {
        SpawnTimer();

        if(WaveNEndlessToggle == true)
        {
            ModeTxt.text = "Mode : Wave";
        }
        else if(WaveNEndlessToggle == false)
        {
            ModeTxt.text = "Mode : Endless";
        }
    }

    void SpawnTimer()
    {
        if (isTimer)
        {
            if (SpawnTimeTxt.gameObject.activeInHierarchy == true)
            {
                ShowTimer -= Time.deltaTime;
                SpawnTimeTxt.text = "Next Wave Spawn in " + Mathf.Round(ShowTimer).ToString();
                SpawnTimeTxt1.text = "Next Wave Spawn in " + Mathf.Round(ShowTimer).ToString();
            }
            if (ShowTimer <= 0)
            {
                SpawnTimeTxt.gameObject.SetActive(false);
                SpawnTimeTxt1.gameObject.SetActive(false);
                if (WaveNEndlessToggle)
                {
                    if (preSpawn)
                    {
                        preSpawn = false;
                        spawnCount += 2f;
                        isTimer = false;
                        StartCoroutine(WaveSpawn());
                    }
                }
                else
                {
                    TimeFix += 4f;
                    spawnCount += 2f;
                    isTimer = false;
                    StartCoroutine(EndlessSpawn());
                }
            }
        }
    }

    public void WaveMode()
    {
        TimeFix = 3f;
        ShowTimer = TimeFix;
        spawnCount = 3f;
        isTimer = true;
        WaveNEndlessToggle = true;
        isNextWave = true;
        preSpawn = true;
        SpawnTimeTxt.gameObject.SetActive(true);
        SpawnTimeTxt1.gameObject.SetActive(true);
    }
    public void NextWave()
    {
        if (isNextWave)
        {
            isNextWave = false;
            isTimer = true;
            preSpawn = true;
            ShowTimer = TimeFix;
            SpawnTimeTxt.gameObject.SetActive(true);
            SpawnTimeTxt1.gameObject.SetActive(true);
        }
    }
    public void EndlessMode()
    {
        isTimer = true;
        WaveNEndlessToggle = false;
        isNextWave = false;
        preSpawn = false;
        TimeFix = 3f;
        ShowTimer = TimeFix;
        spawnCount = 3f;
        SpawnTimeTxt.gameObject.SetActive(true);
        SpawnTimeTxt1.gameObject.SetActive(true);
    }

    IEnumerator WaveSpawn()
    {
        s_GMPlayTest.PlayNPlanToggle = true;
        inAction = true;
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(EnemyPrefab, EnemySpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);

            if (!WaveNEndlessToggle)
            {
                break;
            }
        }
        if (!WaveNEndlessToggle)
        {
            yield break;
        }
        isNextWave = true;
        s_GMPlayTest.PlayNPlanToggle = false;
        DC.NewCard();
        inAction = false;
    }

    IEnumerator EndlessSpawn()
    {
        s_GMPlayTest.PlayNPlanToggle = true;
        inAction = true;
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(EnemyPrefab, EnemySpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);

            if (WaveNEndlessToggle)
            {
                break;
            }
        }
        if (WaveNEndlessToggle)
        {
            yield break;
        }
        inAction = false;
        DC.NewCard();

        yield return new WaitForSeconds(3f);
        s_GMPlayTest.PlayNPlanToggle = false;
        isTimer = true;
        ShowTimer = TimeFix;
        SpawnTimeTxt.gameObject.SetActive(true);
        SpawnTimeTxt1.gameObject.SetActive(true);
    }
}
