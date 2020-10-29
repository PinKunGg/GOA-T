using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CardScript : MonoBehaviour
{
    Material Startmaterial;
    Renderer rend;
    CardInHand cardInHand;
    DeckCollect DeckCollect;
    BuildManager buildManager;
    Card_GM Card_GM;
    public Material OverMaterial, ClickMaterial;
    public int CardIndex;
    public int PosIndex;
    public bool isSelect;

    private void Awake()
    {
        DeckCollect = GameObject.Find("GM").GetComponent<DeckCollect>();
        cardInHand = GameObject.Find("GM").GetComponent<CardInHand>();
        buildManager = GameObject.Find("GM").GetComponent<BuildManager>();
        Card_GM = GameObject.Find("GM").GetComponent<Card_GM>();
        rend = GetComponent<MeshRenderer>();
    }
    private void OnDestroy()
    {
        Card_GM.CardScripts[PosIndex] = null;
    }
    private void Start()
    {
        Card_GM.CardScripts[PosIndex] = this.gameObject;
        Startmaterial = this.rend.material;
    }
    private void OnMouseEnter()
    {
        if(isSelect == false)
        {
            this.rend.material = OverMaterial;
        }
    }
    private void OnMouseDown()
    {
        isSelect = true;
        buildManager.isBuild = false;
        cardInHand.CardSelectIndex = this.PosIndex;
        buildManager.CardIndexRevice(this.CardIndex);
        Card_GM.CardClickIndexRevice(this.PosIndex);
    }

    private void OnMouseExit()
    {
        if(isSelect == false)
        {
            this.rend.material = Startmaterial;
        }
    }
}
