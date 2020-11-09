using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public Text TurretPreview;
    public static BuildManager instance;
    public GameObject standardCannonPrefab, TurretPreviewSpawnPos;
    public Card_ScriptAbleObject[] CardTurretList;
    GameObject cannonToBuild;
    public int CardIndex;
    public bool isBuild = true, isPause;
    public float TurretCost;

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
    public float GetTurretCost()
    {
        return TurretCost;
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

        ClearPreviewData();
    }
    public void CardIndexRevice(int value)
    {
        CardIndex = value;
        CheckIndexTurret();
    }
    public void ClearPreviewData()
    {
        foreach(Transform item in TurretPreviewSpawnPos.transform)
        {
            Destroy(item.gameObject);
        }
        TurretPreview.text = "Name: \t- \n\nDamage: \t- \n\nRotate Speed: \t- \n\nFireRate / s: \t- \n\nCost: \t-";
    }
    void CheckIndexTurret()
    {
        foreach(Transform item in TurretPreviewSpawnPos.transform)
        {
            Destroy(item.gameObject);
        }
        
        if(CardIndex == 1)
        {
            cannonToBuild = CardTurretList[0].Turret;
            TurretCost = CardTurretList[0].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[0].TurretName + "\n\nDamage: \t" + CardTurretList[0].Damage + "\n\nRotate Speed: \t" + CardTurretList[0].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[0].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(CardIndex == 2)
        {
            cannonToBuild = CardTurretList[1].Turret;
            TurretCost = CardTurretList[1].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[1].TurretName + "\n\nDamage: \t" + CardTurretList[1].Damage + "\n\nRotate Speed: \t" + CardTurretList[1].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[1].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(CardIndex == 3)
        {
            cannonToBuild = CardTurretList[2].Turret;
            TurretCost = CardTurretList[2].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[2].TurretName + "\n\nDamage: \t" + CardTurretList[2].Damage + "\n\nRotate Speed: \t" + CardTurretList[2].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[2].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(CardIndex == 4)
        {
            cannonToBuild = CardTurretList[3].Turret;
            TurretCost = CardTurretList[3].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[3].TurretName + "\n\nDamage: \t" + CardTurretList[3].Damage + "\n\nRotate Speed: \t" + CardTurretList[3].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[3].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(CardIndex == 5)
        {
            cannonToBuild = CardTurretList[4].Turret;
            TurretCost = CardTurretList[4].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[4].TurretName + "\n\nDamage: \t" + CardTurretList[4].Damage + "\n\nRotate Speed: \t" + CardTurretList[4].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[4].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(CardIndex == 6)
        {
            cannonToBuild = CardTurretList[5].Turret;
            TurretCost = CardTurretList[5].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[5].TurretName + "\n\nDamage: \t" + CardTurretList[5].Damage + "\n\nRotate Speed: \t" + CardTurretList[5].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[5].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else if(CardIndex == 7)
        {
            cannonToBuild = CardTurretList[6].Turret;
            TurretCost = CardTurretList[6].Cost;
            TurretPreview.text = "Name: \t" + CardTurretList[6].TurretName + "\n\nDamage: \t" + CardTurretList[6].Damage + "\n\nRotate Speed: \t" + CardTurretList[6].RotateSpeed + "\n\nFireRate / s: \t" + CardTurretList[6].FireRate + "\n\nCost: \t" + TurretCost;
            GameObject Preview = Instantiate(cannonToBuild, TurretPreviewSpawnPos.transform.position, TurretPreviewSpawnPos.transform.rotation);
            Preview.transform.parent = TurretPreviewSpawnPos.transform;
            Preview.transform.localScale = new Vector3(1f,1f,1f);
        }
        else
        {
            cannonToBuild = standardCannonPrefab;
            TurretPreview.text = "Name: \t- \n\nDamage: \t- \n\nRotate Speed: \t- \n\nFireRate / s: \t- \n\nCost: \t-";
        }
    }
}
