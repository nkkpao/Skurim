using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHero : BaseEntity
{
    //private Inventory _inventory;
    public BasicHero(int maxHp = 20, int armor = 0, int speed = 2, int attackDmg = 4)
    {
        MaxHp = maxHp;
        CurHp = MaxHp;
        Armor = armor;
        Speed = speed;
        AttackDamage = attackDmg;
    }
}
