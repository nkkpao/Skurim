using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New entity", menuName = "Scriptable entity")]

public class ScriptableEntity : ScriptableObject
{
    public string Name;
    public Faction Faction;
    public BaseEntity EntityPrefab;
    //public int MaxHp, armor, speed, attackDmg;
}



public enum Faction
{
    Hero = 0,
    Enemy = 1
}