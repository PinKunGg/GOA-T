using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildZone : MonoBehaviour
{
    public Color color_HoverColor;
    Color color_StartColor;

    public Text txt_SystemText, txt_SystemText_S;
    GameObject g_cannon;
    public Vector3 v3_CannonOffSet;

    Renderer render_rend;
    DeckCollect s_DC;
    GM s_GM;
    CardInHand s_CardInHand;
    public int CardSelectIndex;

    void Awake() //GetComponent
    {
        render_rend = GetComponent<Renderer>();
        txt_SystemText = GameObject.Find("SystemTxt_T").GetComponent<Text>();
        txt_SystemText_S = GameObject.Find("SystemTxt_S").GetComponent<Text>();
        s_DC = GameObject.Find("GM").GetComponent<DeckCollect>();
        s_GM = GameObject.Find("GM").GetComponent<GM>();
        s_CardInHand = GameObject.Find("GM").GetComponent<CardInHand>();
    }
    void Start()
    {
        //Set System Text to null
        txt_SystemText.text = "";
        txt_SystemText_S.text = "";

        //Store BuildZone Current Color
        color_StartColor = render_rend.material.color;
    }
    private void OnMouseDown() //When Click on this BuildZone
    {
        if(g_cannon != null) //Check if there is any cannon on there
        {
            txt_SystemText.text = "Can't Deploy Here";
            txt_SystemText_S.text = "Can't Deploy Here";
            Invoke("ResetSystemTxt", 4f);
            return;
        }
        else if (s_DC.InHandCard != 0 && s_GM.b_PlaneTurn == true) //Check it is in PlaneTurn of have any card left
        {
            bool isBuild = BuildManager.instance.GetIsBuild();
            bool isPause = BuildManager.instance.GetIsPause();
            if(isBuild == false && isPause == false)
            {
                BuildManager.instance.isBuild = true;
                int CardIndex = BuildManager.instance.GetCardIndex();
                print("Summon Turret = " + CardIndex);
                GameObject cannonToBuild = BuildManager.instance.GetCannonToBuild();
                g_cannon = (GameObject)Instantiate(cannonToBuild, transform.position + v3_CannonOffSet, transform.rotation);
                s_CardInHand.RemoveSpawnCard();
            }
            else if(isBuild == true && isPause == false)
            {
                txt_SystemText.text = "Please select a card!";
                txt_SystemText_S.text = "Please select a card!";
                Invoke("ResetSystemTxt", 4f);
            }
            else
            {

            }
        }
        else if (s_GM.b_PlayTurn == true) //When it in PlaneTurn can't build
        {
            txt_SystemText.text = "Wait until 'PlanTurn' !";
            txt_SystemText_S.text = "Wait until 'PlanTurn' !";
            Invoke("ResetSystemTxt", 4f);
        }
        else //Not have any card left in Hand
        {
            txt_SystemText.text = "Not have any card left in Hand!";
            txt_SystemText_S.text = "Not have any card left in Hand!";
            Invoke("ResetSystemTxt", 4f);
        }
        
    }
    private void OnMouseEnter() //Chance Color when mouse on that BuildZone
    {
        bool isPause = BuildManager.instance.GetIsPause();
        if(isPause == true)
        {

        }
        else
        {
            render_rend.material.color = color_HoverColor;
        }
    }

    private void OnMouseExit() //Chance Color when mouse not on that BuildZone
    {
        render_rend.material.color = color_StartColor;
    }
    void ResetSystemTxt() //Reset SystemText
    {
        txt_SystemText.text = "";
        txt_SystemText_S.text = "";
    }
}
