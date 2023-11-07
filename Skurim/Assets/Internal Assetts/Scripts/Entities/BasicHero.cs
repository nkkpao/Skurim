using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHero : BaseEntity
{
    //protected Inventory _inventory;
    //protected int Level { get; set; }
    //protected int CurXp { get; set; }
    //protected int TargetXp { get; set; }
    public BasicHero(int maxHp = 20, int armor = 0, int speed = 2, int attackDmg = 4)
    {
        MaxHp = maxHp;
        CurHp = MaxHp;
        Armor = armor;
        Speed = speed;
        AttackDamage = attackDmg;
    }
}
