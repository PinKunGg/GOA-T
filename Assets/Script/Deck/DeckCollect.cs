using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeckCollect : MonoBehaviour
{
    public List<string> L_Deck, L_DeckStorage;
    public Text txt_CardCount;
    string DeckPath = Application.streamingAssetsPath + "/Deck.txt";
    string card = "";
    StreamReader reader;
    CardInHand cardInHand;
    private void Awake()
    {
        cardInHand = GetComponent<CardInHand>();
    }
    void Start()
    {
        ReadFile_DeckStorageList();
        AddCardToDeckStorage();
        NewCard();
    }
    void Update()
    {
        //Display Card in Deck & Card in Hand
        txt_CardCount.text = "" + L_Deck.Count;
    }
    void ReadFile_DeckStorageList() //Read Card from StreamReader and Add To DeckStorage
    {
        reader = new StreamReader(DeckPath);
        while (card != null)
        {
            card = reader.ReadLine();

            if (card != null)
            {
                L_DeckStorage.Add(card);
            }
        }
    }
    void AddCardToDeckStorage()
    {
        for (int i = 1; i <= 30; i++)
        {
            addCard();
        }
    }
    public void NewCard()
    {
        if(InHandCard != 5)
        {
            SendStorageCardToHand();
        }
    }
    public int InHandCard = 0;
    bool isSpawnCard = false;
    void SendStorageCardToHand()
    {
        for(int i = 0; i < 5; i++)
        {
            cardInHand.CardIndex = int.Parse(L_Deck[i]);
            if(isSpawnCard == false)
            {
                cardInHand.indexSpawnPos = i;
                cardInHand.SpawnCard();
            }
            else
            {
                cardInHand.indexSpawnPos = i;
                cardInHand.DrawNewCard();
            }
        }
        isSpawnCard = true;
    }
    
    public void addCard() //Random Add Card in DeckStorage to Deck that ready to Play
    {
        float rand = Random.Range(1, 8);
        
        switch (rand)
        {
            case 1:
                L_Deck.Add(L_DeckStorage[0]);
                break;
            case 2:
                L_Deck.Add(L_DeckStorage[1]);
                break;
            case 3:
                L_Deck.Add(L_DeckStorage[2]);
                break;
            case 4:
                L_Deck.Add(L_DeckStorage[3]);
                break;
            case 5:
                L_Deck.Add(L_DeckStorage[4]);
                break;
            case 6:
                L_Deck.Add(L_DeckStorage[5]);
                break;
            case 7:
                L_Deck.Add(L_DeckStorage[6]);
                break;
            default:
                L_Deck.Add("Fu*k!");
                break;
        }
    }
}
