using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCount : MonoBehaviour
{
    private void Update()
    {
        GameObject.Find("lblCountMain").GetComponent<Text>().text = "Spinnenanzahl: " + GameObject.Find("Informations").GetComponent<SaveInformations>().count.ToString();
    }
}
