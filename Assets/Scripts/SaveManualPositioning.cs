using UnityEngine;
using UnityEngine.UI;

/**
* This script saves the selection of manual positioning
* 
* @author: Huy Duc Do
* 
**/
public class SaveManualPositioning : MonoBehaviour
{
    /// <summary>
    /// Used to save the selection of manual positioning in the global variable manualPositioning and disables/enables the increase/decrease spawning buttons
    /// </summary>
    public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning = GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn;

        if(GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn)
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
}
