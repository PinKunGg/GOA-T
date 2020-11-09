using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "GOAT/Cards")]
public class Card_ScriptAbleObject : ScriptableObject
{
    public string Name = "New Card";
    public int CardIndex = 0;
    public GameObject Turret;

    public string TurretName = "Turret 0";
    public float DetecRange = 4f;
    public float Damage = 5f;
    public float RotateSpeed = 10f;
    public float FireRate = 5f;
    public float Cost = 3f;
}
