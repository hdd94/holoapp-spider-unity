using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDevMode : MonoBehaviour {

	public void Save()
    {
        //GameObject.Find("btnConform").GetComponent<SaveInformations>().developerMode = GameObject.Find("DeveloperMode").GetComponent<Toggle>().isOn;
        GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode = GameObject.Find("DeveloperMode").GetComponent<Toggle>().isOn;
    }
}
