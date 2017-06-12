using UnityEngine;
using UnityEngine.UI;

/**
* This script saves the toggle selection of the movementKind randomly
* 
* @author: Huy Duc Do
* 
**/
public class SaveRandomToggle : MonoBehaviour
{
    /// <summary>
    /// Used to save the toggle selection of the movementKind randomly in the global 
    /// variable randomMovementToggle
    /// </summary>
    public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle = GameObject.Find("RandomToggle").GetComponent<Toggle>().isOn;
    }
}
