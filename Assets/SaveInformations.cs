using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInformations : MonoBehaviour {

    public int count;
    public bool randomMovementToggle;
    public bool directMovementToggle;
    public bool developerMode;
    public bool unityMode;
    public bool manualPositioning;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        //count = Convert.ToInt32(GameObject.Find("lblMainCount").GetComponent<Text>().text);
        //movementKind = GameObject.Find("Dropdown").GetComponent<Dropdown>().value;
        //developerMode = GameObject.Find("DeveloperMode").GetComponent<Toggle>().isOn;

        //count = 3;
        //movementKind = 0;
        //developerMode = false;
        //unityMode = false;
        //manualPositioning = false;
    }
}
