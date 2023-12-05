using UnityEngine;

[CreateAssetMenu(fileName = "New entity", menuName = "Scriptable entity")]

public class ScriptableEntity : ScriptableObject
{
    public string Name;
    public Faction faction;
    public GameObject entityPrefab;
    public GameObject ATBGaugePF;
    public GameObject hpGaugePF;
    //public int MaxHp, armor, speed, attackDmg;
}



public enum Faction
{
    Hero = 0,
    Enemy = 1
}