using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : BaseEntity
{
    public void init(int maxHp = 10, int armor = 0, int speed = 2, int attackDmg = 4)
    {
        MaxHp = maxHp;
        CurHp = MaxHp;
        Armor = armor;
        Speed = speed;
        AttackDamage = attackDmg;
    }
}
