using UnityEngine;
using UnityEngine.UI;

/**
* This Script saves the toggle selection of the movementKind randomly and directly
* 
* @author: Huy Duc Do
* 
**/
public class SaveBothToggle : MonoBehaviour
{
    /// <summary>
    /// Used to save the toggle selection of the movementKind randomly and directly 
    /// in the global variable bothMovementToggle
    /// </summary>
    public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().bothMovementToggle = GameObject.Find("BothToggle").GetComponent<Toggle>().isOn;
    }
}
