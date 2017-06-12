using System;
using UnityEngine;
using UnityEngine.UI;

/**
* This script updates the movementKind if the spider movementKind changes
* 
* @author: Huy Duc Do
* 
**/
public class UpdateMovementKind : MonoBehaviour
{
    String movementKind;

    /// <summary>
    /// Update is called once per frame
    /// Used to update the movementKind if the spider movementKind changes
    /// </summary>
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
