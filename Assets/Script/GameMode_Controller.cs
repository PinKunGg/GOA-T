using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMode_Controller : MonoBehaviour
{
    [Header("Mode")]
    bool WaveNEndlessToggle = true;
    /*
     * WaveNEndless = true -> Wave
     * WaveNEndless = false -> Endless
     */
    bool isNextWave = false;
    bool preSpawn = false;
    public Text ModeTxt;

    [Header("Spawner")]
    public GameObject EnemyPrefab;
    GameObject EnemySpawner;
    float spawnCount = 3f;

    [Header("Timer")]
    static float TimeFix = 3f;
    float ShowTimer;
    bool isTimer = false;
    public Text SpawnTimeTxt;

    void Start()
    {
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");

        SpawnTimeTxt.gameObject.SetActive(false);
    }
    void Update()
    {
        SpawnTimer();
    }

    void SpawnTimer()
    {
        if (isTimer)
        {
            if (SpawnTimeTxt.gameObject.activeInHierarchy == true)
            {
                ShowTimer -= Time.deltaTime;
                SpawnTimeTxt.text = "Next Wave Spawn in " + Mathf.Round(ShowTimer).ToString();
            }
            if (ShowTimer <= 0)
            {
                SpawnTimeTxt.gameObject.SetActive(false);
                if (WaveNEndlessToggle)
                {
                    if (preSpawn)
                    {
                        preSpawn = false;
                        TimeFix += 4f;
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
        isTimer = true;
        ModeTxt.text = "Mode : Wave";
        WaveNEndlessToggle = true;
        isNextWave = true;
        preSpawn = true;
        TimeFix = 3f;
        ShowTimer = TimeFix;
        spawnCount = 3f;
        SpawnTimeTxt.gameObject.SetActive(true);
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
        }
    }

    public void EndlessMode()
    {
        isTimer = true;
        ModeTxt.text = "Mode : Endless";
        WaveNEndlessToggle = false;
        isNextWave = false;
        preSpawn = false;
        TimeFix = 3f;
        ShowTimer = TimeFix;
        spawnCount = 3f;
        SpawnTimeTxt.gameObject.SetActive(true);
    }

    IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(EnemyPrefab, EnemySpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

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
    }

    IEnumerator EndlessSpawn()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(EnemyPrefab, EnemySpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);

            if (WaveNEndlessToggle)
            {
                break;
            }
        }
        if (WaveNEndlessToggle)
        {
            yield break;
        }

        yield return new WaitForSeconds(5f);
        isTimer = true;
        ShowTimer = TimeFix;
        SpawnTimeTxt.gameObject.SetActive(true);
    }
}
