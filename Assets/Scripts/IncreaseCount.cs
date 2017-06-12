using System;
using UnityEngine;
using UnityEngine.UI;

/**
* This script increases the number of spawning objects 
* 
* @author: Huy Duc Do
* 
**/
public class IncreaseCount : MonoBehaviour
{
    /// <summary>
    /// Used to increase the number of spawning objects if number is less than maximum count
    /// </summary>
    public void Increase()
    {
        string n = GameObject.Find("lblMainCount").GetComponent<Text>().text;
        int number = Convert.ToInt32(n);

        int maxCount = GameObject.Find("Informations").GetComponent<SaveInformations>().maxCount;
        if (number < maxCount)
        {
            number++;
        }

        string str = number.ToString();
        GameObject.Find("lblMainCount").GetComponent<Text>().text = str;

        GameObject.Find("Informations").GetComponent<SaveInformations>().count = number;
    }
}
