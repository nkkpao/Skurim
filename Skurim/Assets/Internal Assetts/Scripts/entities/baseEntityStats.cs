using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class baseEntity 
{

    public int MaxHp { get; protected set; }
    public int CurHp { get; protected set; }
    public int Armor { get; protected set; }
    public int Speed { get; protected set; }

}
