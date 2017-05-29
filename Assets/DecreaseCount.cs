using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseCount : MonoBehaviour {

    public void Decrease()
    {
        string n = GameObject.Find("lblMainCount").GetComponent<Text>().text;
        int number = Convert.ToInt32(n);


        if(number > 0)
        {
            number--;
        }


        string str = number.ToString();
        GameObject.Find("lblMainCount").GetComponent<Text>().text = str;
        Debug.Log(str);
    }
}
