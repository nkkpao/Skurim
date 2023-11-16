using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEntity : MonoBehaviour
{
    public int AttackDamage { get; protected set; }
    public int MaxHp { get; protected set; }
    public int CurHp { get; protected set; }
    public int Armor { get; protected set; }
    public int Speed { get; protected set; }

    public virtual int Attack(BaseEntity target)
    {
        int rndAttack = Random.Range(0, AttackDamage);
        target.CurHp = CurHp - rndAttack;
        return rndAttack;
    }

}
