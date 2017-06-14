using System;
using UnityEngine;
using UnityEngine.UI;

/**
* This script contains functions to change values of the global options variables spiderCount, developerMode, manualPositioning, unityMode
* 
* @author: Huy Duc Do
* 
**/
public class OptionsPanelController : MonoBehaviour {

    public Text mainCountText;
    public Text mainMenuCountText;
    public Button countIncreaseButton;
    public Button countDecreaseButton;
    public Toggle developerModeToggle;
    public Toggle manualPositioningToggle;
    public Toggle unityModeToggle;

    /// <summary>
    /// Used to increase the number of spawning objects if number is less than maximum count
    /// </summary>
    public void IncreaseMainCount()
    {
        int number = SaveInformations.Instance.count;
        int maxCount = SaveInformations.Instance.maxCount;

        if(number < maxCount)
        {
            number++;
        }

        mainCountText.text = number.ToString();
        mainMenuCountText.text = "Spinnenanzahl: " + number;
        SaveInformations.Instance.count = number;
    }

    /// <summary>
    /// Used to decrease the number of spawning objects if number is higher than 1
    /// </summary>
    public void DecreaseMainCount()
    {
        int number = SaveInformations.Instance.count;

        if (number > 1)
        {
            number--;
        }

        mainCountText.text = number.ToString();
        mainMenuCountText.text = "Spinnenanzahl: " + number;
        SaveInformations.Instance.count = number;
    }

    /// <summary>
    /// Used to save the selection of developer mode in the global variable developerMode
    /// </summary>
	public void SaveDeveloperModeToggle()
    {
        SaveInformations.Instance.developerMode = developerModeToggle.isOn;
    }

    /// <summary>
    /// Used to save the selection of manual positioning in the global variable manualPositioning and disables/enables the increase/decrease spawning buttons
    /// </summary>
    public void SaveManualPositioningToggle()
    {
        SaveInformations.Instance.manualPositioning = manualPositioningToggle.isOn;

        if (manualPositioningToggle.isOn)
        {
            countIncreaseButton.interactable = false;
            countDecreaseButton.interactable = false;
        }
        else
        {
            countIncreaseButton.interactable = true;
            countDecreaseButton.interactable = true;
        }
    }

    /// <summary>
    /// Used to save the selection of unity mode in the global variable unityMode
    /// </summary>
    public void SaveUnityModeToggle()
    {
        SaveInformations.Instance.unityMode = unityModeToggle.isOn;
    }
}
