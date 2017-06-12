using UnityEngine;
using UnityEngine.UI;

/**
* This script saves the toggle selection of the movementKind directly
* 
* @author: Huy Duc Do
* 
**/
public class SaveDirectToggle : MonoBehaviour
{
    /// <summary>
    /// Used to save the toggle selection of the movementKind directly 
    /// in the global variable directMovementToggle
    /// </summary>
    public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle = GameObject.Find("DirectToggle").GetComponent<Toggle>().isOn;
    }
}
