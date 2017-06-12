using System;
using UnityEngine;
using UnityEngine.UI;

/**
* This script decreases the number of spawning objects 
* 
* @author: Huy Duc Do
* 
**/
public class DecreaseCount : MonoBehaviour
{
    /// <summary>
    /// Used to decrease the number of spawning objects if number is higher than 1
    /// </summary>
    public void Decrease()
    {
        string n = GameObject.Find("lblMainCount").GetComponent<Text>().text;
        int number = Convert.ToInt32(n);

        if(number > 1)
        {
            number--;
        }

        string str = number.ToString();
        GameObject.Find("lblMainCount").GetComponent<Text>().text = str;

        GameObject.Find("Informations").GetComponent<SaveInformations>().count = number;
    }
}
