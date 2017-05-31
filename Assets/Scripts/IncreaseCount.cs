using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseCount : MonoBehaviour
{

    public void Increase()
    {
        string n = GameObject.Find("lblMainCount").GetComponent<Text>().text;
        int number = Convert.ToInt32(n);


        if (number < 9)
        {
            number++;
        }


        string str = number.ToString();
        GameObject.Find("lblMainCount").GetComponent<Text>().text = str;
        Debug.Log(str);

        //GameObject.Find("btnConform").GetComponent<SaveInformations>().count = number;
        GameObject.Find("Informations").GetComponent<SaveInformations>().count = number;
    }
}
