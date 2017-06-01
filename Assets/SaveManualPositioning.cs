using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManualPositioning : MonoBehaviour {

    public GameObject count;

    public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning = GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn;

        if(GameObject.Find("ManualPositioning").GetComponent<Toggle>().isOn)
        {
            count.SetActive(false);
        } else
        {
            count.SetActive(true);
        }
    }
}
