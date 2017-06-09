using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveBothToggle : MonoBehaviour {

    public void Save()
    {
        //Debug.Log(GameObject.Find("btnConform").GetComponent<SaveInformations>().movementKind = GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        GameObject.Find("Informations").GetComponent<SaveInformations>().bothMovementToggle = GameObject.Find("BothToggle").GetComponent<Toggle>().isOn;
    }
}
