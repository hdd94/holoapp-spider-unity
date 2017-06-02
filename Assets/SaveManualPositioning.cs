using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManualPositioning : MonoBehaviour {

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
