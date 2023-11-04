using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Initiative : MonoBehaviour
{
    public readonly int TargetInitiative = 10;
    public int CurrInitiative { get; protected set; } = 0;

    private Slider slider;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    bool NextTurn(bool isNextTurn) //переписать под observer
    {
        CurrInitiative = (int)slider.value; 
        if (CurrInitiative == TargetInitiative & isNextTurn) 
        {
            CurrInitiative = 0;
            return true;
        }
        else if(CurrInitiative > 10)
            CurrInitiative += 1;
        return false;    
    }
}
