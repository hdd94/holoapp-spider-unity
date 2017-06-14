using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanelController : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    /// <summary>
    /// Used to increase the number of spawning objects if number is less than maximum count
    /// </summary>
    public void IncreaseMainCount()
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

    /// <summary>
    /// Used to decrease the number of spawning objects if number is higher than 1
    /// </summary>
    public void DecreaseMainCount()
    {
        string n = GameObject.Find("lblMainCount").GetComponent<Text>().text;
        int number = Convert.ToInt32(n);

        if (number > 1)
        {
            number--;
        }

        string str = number.ToString();
        GameObject.Find("lblMainCount").GetComponent<Text>().text = str;

        GameObject.Find("Informations").GetComponent<SaveInformations>().count = number;
    }

    /// <summary>
    /// Used to save the selection of developer mode in the global variable developerMode
    /// </summary>
	public void SaveDeveloperModeToggle()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode = GameObject.Find("DeveloperMode").GetComponent<Toggle>().isOn;
    }

    /// <summary>
    /// Used to save the selection of manual positioning in the global variable manualPositioning and disables/enables the increase/decrease spawning buttons
    /// </summary>
    public void SaveManualPositioningToggle()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning = GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn;

        if (GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn)
        {
            GameObject.Find("btnCountIncrease").GetComponent<Button>().interactable = false;
            GameObject.Find("btnCountDecrease").GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject.Find("btnCountIncrease").GetComponent<Button>().interactable = true;
            GameObject.Find("btnCountDecrease").GetComponent<Button>().interactable = true;
        }
    }

    /// <summary>
    /// Used to save the selection of unity mode in the global variable unityMode
    /// </summary>
    public void SaveUnityModeToggle()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().unityMode = GameObject.Find("UnityMode").GetComponent<Toggle>().isOn;
    }
}
