using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManualPositioning : MonoBehaviour {

    public void Save()
    {
        //GameObject.Find("btnConform").GetComponent<SaveInformations>().developerMode = GameObject.Find("DeveloperMode").GetComponent<Toggle>().isOn;
        bool manualPositioning = GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning;
        manualPositioning = GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn;

        if (manualPositioning)
        {
            GameObject.Find("Count").SetActive(false);
        }
        else
        {
            GameObject.Find("Count").SetActive(true);
        }
    }
}
