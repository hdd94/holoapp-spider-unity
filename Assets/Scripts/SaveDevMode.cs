using UnityEngine;
using UnityEngine.UI;

/**
* This script saves the selection of developer mode
* 
* @author: Huy Duc Do
* 
**/
public class SaveDevMode : MonoBehaviour
{
    /// <summary>
    /// Used to save the selection of developer mode in the global variable developerMode
    /// </summary>
	public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode = GameObject.Find("DeveloperMode").GetComponent<Toggle>().isOn;
    }
}
