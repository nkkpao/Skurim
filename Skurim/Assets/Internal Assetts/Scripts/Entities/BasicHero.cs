using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHero : BaseEntity
{
    //protected Inventory _inventory;
    //protected int Level { get; set; }
    //protected int CurXp { get; set; }
    //protected int TargetXp { get; set; }

    public void init(int maxHp = 10, int armor = 0, int speed = 2, int attackDmg = 5)
    {
        MaxHp = maxHp;
        CurHp = MaxHp;
        Armor = armor;
        Speed = speed;
        AttackDamage = attackDmg;
    }

}
