using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDirectToggle : MonoBehaviour {

	 public void Save()
    {
        //Debug.Log(GameObject.Find("btnConform").GetComponent<SaveInformations>().movementKind = GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle = GameObject.Find("DirectToggle").GetComponent<Toggle>().isOn;
    }
}
