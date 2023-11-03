using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initiative : MonoBehaviour
{
    public int initiative1 = 10;
    private Slider slider;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    bool turn(bool action1)
    {
        initiative1 = (int)slider.value; 
        if (initiative1 == 10 & action1) 
        {
            initiative1 = 0;
            return true;
        }
        else if(initiative1 > 10)
            initiative1 += 1;
        return false;    
    }
}
