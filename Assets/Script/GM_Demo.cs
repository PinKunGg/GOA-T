using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GM_Demo : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Text SpawnTimeTxt;
    public Text ModeTxt;

    public GameObject PlaneStageCam;
    public GameObject PlayeStageCam;

    GameObject EnemySpawner;
    float spawnCount = 5f;
    float ShowTimer = 0f;
    static float TimeFix = 3f;
    bool waveNendlessToggle = true;
    bool inSpawn;
    bool EndlessSelect = true;
    bool Timer = false;

    private void Awake()
    {
        ShowTimer = TimeFix;
    }
    private void Start()
    {
        EnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner");

        SpawnTimeTxt.gameObject.SetActive(false);

        StarCam();
    }
    private void LateUpdate()
    {
        /*
        waveNendlessToggle = true -> WaveStart
        waveNendlessToggle = false -> EndlessStart
        */
    }
    private void Update()
    {
        SpawnTimer();
    }

    void StarCam()
    {
        PlaneStageCam.SetActive(true);
        PlayeStageCam.SetActive(false);
    }

    void SpawnTimer()
    {
        if (Timer)
        {
            if (SpawnTimeTxt.gameObject.activeInHierarchy == true)
            {
                inSpawn = false;
                ShowTimer -= Time.deltaTime;
                SpawnTimeTxt.text = "Next Wave Spawn in " + Mathf.Round(ShowTimer).ToString();
            }
            //if (ShowTimer <= 0 && waveNendlessToggle == true)
            //{
            //    SpawnTimeTxt.gameObject.SetActive(false);
            //}
            if (ShowTimer <= 0 && waveNendlessToggle == false)
            {
                SpawnTimeTxt.gameObject.SetActive(false);
                TimeFix += 4f;
                spawnCount += 2f;
                Timer = false;
                StartCoroutine(EndlessSpawner());
            }
        }
    }
    public void PlaneTurn()
    {
        PlaneStageCam.SetActive(true);
        PlayeStageCam.SetActive(false);
    }
    public void PlayTurn()
    {
        PlaneStageCam.SetActive(false);
        PlayeStageCam.SetActive(true);
    }
    public void WaveToggle()
    {
        ModeTxt.text = "Mode: Wave";
        //TimeFix = 5f;
        //spawnCount = 5f;
        //waveNendlessToggle = true;
        //EndlessSelect = true;

        //if (ShowTimer <= 0f && !inSpawn)
        //{
        //    StartCoroutine(WaveSpawn());
        //}
    }
    public void EndlessToggle()
    {
        ModeTxt.text = "Mode: Endless";
        TimeFix = 3f;
        spawnCount = 5f;
        ShowTimer = TimeFix;
        Timer = true;
        SpawnTimeTxt.gameObject.SetActive(true);
        waveNendlessToggle = false;
        if (EndlessSelect)
        {
            EndlessSelect = false;
            StartCoroutine(EndlessSpawner());
        }
    }
    IEnumerator WaveSpawn()
    {
        ShowTimer = TimeFix;
        SpawnTimeTxt.gameObject.SetActive(true);

        yield return new WaitForSeconds(ShowTimer + 0.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            inSpawn = true;
            Instantiate(EnemyPrefab, EnemySpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator EndlessSpawner()
    {
        yield return new WaitForSeconds(ShowTimer + 0.5f);

        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(EnemyPrefab, EnemySpawner.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(5f);
        Timer = true;
        ShowTimer = TimeFix;
        SpawnTimeTxt.gameObject.SetActive(true);
    }
}
