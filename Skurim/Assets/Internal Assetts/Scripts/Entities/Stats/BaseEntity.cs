using System;

[Serializable]
public class BaseEntity
{
    public string name;
    public int AttackDamage;
    public int MaxHp;
    public int CurHp;
    public int Armor;
    public int Speed;

    /*public virtual void init(int maxHp = 0, int armor = 0, int speed = 0, int attackDmg = 0)
    {
        MaxHp = maxHp;
        CurHp = MaxHp;
        Armor = armor;
        Speed = speed;
        AttackDamage = attackDmg;
    }*/

    public virtual int Attack(BaseEntity target)
    {
        int rndAttack = UnityEngine.Random.Range(0, AttackDamage);
        target.CurHp = CurHp - rndAttack;
        return rndAttack;
    }

}
