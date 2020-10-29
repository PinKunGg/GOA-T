using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "GOAT/Cards")]
public class Card_ScriptAbleObject : ScriptableObject
{
    public string Name = "New Card";
    public int CardIndex = 0;
    public GameObject Turret;
}
