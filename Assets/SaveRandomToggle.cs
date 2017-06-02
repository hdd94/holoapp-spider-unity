using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveRandomToggle : MonoBehaviour {

    public void Save()
    {
        //Debug.Log(GameObject.Find("btnConform").GetComponent<SaveInformations>().movementKind = GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle = GameObject.Find("RandomToggle").GetComponent<Toggle>().isOn;
    }
}
