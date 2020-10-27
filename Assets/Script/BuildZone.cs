using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildZone : MonoBehaviour
{
    public Color HoverColor;
    Color StartColor;

    public Text SystemText;
    public Text SystemText_S;
    GameObject cannon;
    public Vector3 CannonOffSet;

    Renderer rend;
    DeckCollect DC;
    GM_PlayTest GMD;

    void Start()
    {
        rend = GetComponent<Renderer>();
        SystemText = GameObject.Find("SystemTxt_T").GetComponent<Text>();
        SystemText_S = GameObject.Find("SystemTxt_S").GetComponent<Text>();
        DC = GameObject.Find("GM_PlayTest").GetComponent<DeckCollect>();
        GMD = GameObject.Find("GM_PlayTest").GetComponent<GM_PlayTest>();
        SystemText.text = "";
        SystemText_S.text = "";
        StartColor = rend.material.color;
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(cannon != null)
        {
            SystemText.text = "Can't Deploy Here";
            SystemText_S.text = "Can't Deploy Here";
            Invoke("ResetSystemTxt", 4f);
            return;
        }
        else if (DC.HandCard != 0 && GMD.PlayNPlanToggle == false)
        {
            DC.RemoveCardInHand();
            GameObject cannonToBuild = BuildManager.instance.GetCannonToBuild();
            cannon = (GameObject)Instantiate(cannonToBuild, transform.position + CannonOffSet, transform.rotation);
        }
        else if (GMD.PlayNPlanToggle == true)
        {
            SystemText.text = "Wait until PlanTurn!";
            Invoke("ResetSystemTxt", 4f);
        }
        else
        {
            SystemText.text = "Not have any card in Hand!";
            Invoke("ResetSystemTxt", 4f);
        }
        
    }
    private void OnMouseEnter()
    {
        rend.material.color = HoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = StartColor;
    }
    void ResetSystemTxt()
    {
        SystemText.text = "";
        SystemText_S.text = "";
    }
}
