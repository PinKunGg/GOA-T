using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DeckCollect : MonoBehaviour
{
    public List<string> Deck;
    public List<string> DeckStorage;
    public Text CardCount;
    public Text CardHand;
    public float DeckAmount;
    public int HandCard;

    string DeckPath = Application.streamingAssetsPath + "/Deck.txt";
    string card = "";
    StreamReader reader;

    void Start()
    {
        AddDeckList();
        StartDuel();
        NewCard();
    }
    void StartDuel()
    {
        for (int i = 1; i <= 30; i++)
        {
            addCard();
        }
    }
    public void NewCard()
    {
        for(int i = HandCard; HandCard < 5;)
        {
            removeCard();
            HandCard ++;
        }
    }
    public void RemoveCardInHand()
    {
        HandCard--;
    }
    void Update()
    {
        CardCount.text = "" + Deck.Count;
        CardHand.text = "" + HandCard;
        DeckAmount = Deck.Count;
    }

    void AddDeckList()
    {
        reader = new StreamReader(DeckPath);
        while (card != null)
        {
            card = reader.ReadLine();

            if (card != null)
            {
                DeckStorage.Add(card);
            }
        }
    }
    public void addCard()
    {
        float rand = Random.Range(1, 6);
        switch (rand)
        {
            case 1:
                Deck.Add(DeckStorage[0]);
                break;
            case 2:
                Deck.Add(DeckStorage[1]);
                break;
            case 3:
                Deck.Add(DeckStorage[2]);
                break;
            case 4:
                Deck.Add(DeckStorage[3]);
                break;
            case 5:
                Deck.Add(DeckStorage[4]);
                break;
            default:
                Deck.Add("Fu*k!");
                break;
        }
    }
    public void removeCard()
    {
        Deck.RemoveAt(Deck.Count - 1);
    }
}
