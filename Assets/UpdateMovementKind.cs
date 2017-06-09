using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMovementKind : MonoBehaviour
{
    String movementKind;

    private void Update()
    {
        if (GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle)
            movementKind = "zufällig";
        else if (GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle)
            movementKind = "direkt";
        else if (GameObject.Find("Informations").GetComponent<SaveInformations>().bothMovementToggle)
            movementKind = "zufällig/direkt";

        GameObject.Find("lblMovementKind").GetComponent<Text>().text = "Bewegungsart: " + movementKind;
    }
}
