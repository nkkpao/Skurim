using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero1 : baseEntity
{
    public hero1()
    {
        MaxHp = 20;
        CurHp = MaxHp;
        Armor = 0;
        Speed = 2;
    }

    int damage()
    {
        return Random.Range(0, 4);
    }
}
