using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInHand : MonoBehaviour
{
    public List<GameObject> CardScripts = new List<GameObject>(5);
    public List<GameObject> CardSpawnPos;
    public int indexSpawnPos;
    public int CardIndex;
    public int CardSelectIndex;
    public GameObject CardPrefab;
    DeckCollect DeckCollect;
    private void Awake()
    {
        DeckCollect = GetComponent<DeckCollect>();
    }
    public void SpawnCard()
    {
        GameObject card = Instantiate(CardPrefab,CardSpawnPos[indexSpawnPos].transform.position,CardSpawnPos[indexSpawnPos].transform.rotation);
        card.transform.parent = CardSpawnPos[indexSpawnPos].transform;
        card.GetComponent<CardScript>().CardIndex = this.CardIndex;
        card.GetComponent<CardScript>().PosIndex = this.indexSpawnPos;
        CardScripts[indexSpawnPos] = card;
        DeckCollect.InHandCard++;
        DeckCollect.L_Deck.Remove(DeckCollect.L_Deck[indexSpawnPos]);
    }
    public void DrawNewCard()
    {
        if(CardScripts[indexSpawnPos] == null)
        {
            GameObject card = Instantiate(CardPrefab,CardSpawnPos[indexSpawnPos].transform.position,CardSpawnPos[indexSpawnPos].transform.rotation);
            card.transform.parent = CardSpawnPos[indexSpawnPos].transform;
            card.GetComponent<CardScript>().CardIndex = this.CardIndex;
            card.GetComponent<CardScript>().PosIndex = this.indexSpawnPos;
            CardScripts[indexSpawnPos] = card;
            DeckCollect.InHandCard++;
            DeckCollect.L_Deck.Remove(DeckCollect.L_Deck[indexSpawnPos]);
        }
        else
        {
            //print("This pos is not null = " + indexSpawnPos);
        }
    }
    public void RemoveSpawnCard()
    {
        indexSpawnPos = 0;
        DeckCollect.InHandCard--;
        Destroy(CardScripts[CardSelectIndex].gameObject);
        CardScripts[CardSelectIndex] = null;
    }
}
