using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity 
{
    public int AttackDamage { get; protected set; }
    public int MaxHp { get; protected set; }
    public int CurHp { get; protected set; }
    public int Armor { get; protected set; }
    public int Speed { get; protected set; }

    public virtual int Attack()
    {
        return Random.Range(0, AttackDamage);
    }
}
