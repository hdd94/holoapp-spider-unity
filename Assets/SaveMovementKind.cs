using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMovementKind : MonoBehaviour {
    public void Save()
    {
        //Debug.Log(GameObject.Find("btnConform").GetComponent<SaveInformations>().movementKind = GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
        Debug.Log(GameObject.Find("Informations").GetComponent<SaveInformations>().movementKind = GameObject.Find("Dropdown").GetComponent<Dropdown>().value);
    }
}
