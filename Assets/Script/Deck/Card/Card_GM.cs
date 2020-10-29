using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_GM : MonoBehaviour
{
    public List<GameObject> CardScripts;
    public Material ClickMaterial, StartMaterial;
    public int CardClickIndex;
    public int PastCardClickIndex;
    public void CardClickIndexRevice(int value)
    {
        if(value != PastCardClickIndex)
        {
            try
            {
                CardScripts[PastCardClickIndex].GetComponent<CardScript>().isSelect = false;
            }
            catch
            {

            }

            ChangeMaterialBack(CardClickIndex);
            CardClickIndex = value;
            ClickMaterialChange(CardClickIndex);
            PastCardClickIndex = CardClickIndex;
        }
        else
        {
            ClickMaterialChange(CardClickIndex);
        }
    }
    public void ClickMaterialChange(int value)
    {
        CardScripts[value].GetComponent<Renderer>().material = ClickMaterial;
    }
    void ChangeMaterialBack(int value)
    {
        try
        {
            CardScripts[value].GetComponent<Renderer>().material = StartMaterial;
        }
        catch
        {
            
        }
    }
}
