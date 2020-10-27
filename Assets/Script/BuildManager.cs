using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardCannonPrefab;
    GameObject cannonToBuild;

    public GameObject GetCannonToBuild()
    {
        return cannonToBuild;
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Nani! have more than BuildManager...sh*t I'M QUIT!!");
            return;
        }
        
        instance = this;
    }
    void Start()
    {
        cannonToBuild = standardCannonPrefab;
    }
}
