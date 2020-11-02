using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardCannonPrefab;
    public Card_ScriptAbleObject[] CardTurretList;
    GameObject cannonToBuild;
    public int CardIndex;
    public bool isBuild = true, isPause;

    public GameObject GetCannonToBuild() //Return Build cannon
    {
        return cannonToBuild;
    }
    public int GetCardIndex()
    {
        return CardIndex;
    }
    public bool GetIsBuild()
    {
        return isBuild;
    }
    public bool GetIsPause()
    {
        return isPause;
    }
    private void Awake() //Make this script can have only one on Scene
    {
        if(instance != null)
        {
            Debug.LogError("Nani! Have more than one BuildManager!!");
            return;
        }
        
        instance = this;
    }
    void Start()
    {
        cannonToBuild = standardCannonPrefab;
    }
    public void CardIndexRevice(int value)
    {
        CardIndex = value;
        CheckIndexTurret();
    }
    void CheckIndexTurret()
    {
        if(CardIndex == 1)
        {
            cannonToBuild = CardTurretList[0].Turret;
        }
        else if(CardIndex == 2)
        {
            cannonToBuild = CardTurretList[1].Turret;
        }
        else if(CardIndex == 3)
        {
            cannonToBuild = CardTurretList[2].Turret;
        }
        else if(CardIndex == 4)
        {
            cannonToBuild = CardTurretList[3].Turret;
        }
        else if(CardIndex == 5)
        {
            cannonToBuild = CardTurretList[4].Turret;
        }
        else if(CardIndex == 6)
        {
            cannonToBuild = CardTurretList[5].Turret;
        }
        else if(CardIndex == 7)
        {
            cannonToBuild = CardTurretList[6].Turret;
        }
        else
        {
            cannonToBuild = standardCannonPrefab;
        }
    }
}
