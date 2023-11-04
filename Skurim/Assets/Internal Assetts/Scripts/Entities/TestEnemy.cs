using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : BaseEntity
{
    public TestEnemy()
    {
        MaxHp = 20;
        CurHp = MaxHp;
        Armor= 0;
        Speed = 2;
        AttackDamage = 4;
    }
}
