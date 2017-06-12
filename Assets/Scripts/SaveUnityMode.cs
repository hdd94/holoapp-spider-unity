using UnityEngine;
using UnityEngine.UI;

/**
* This script saves the selection of unity mode
* 
* @author: Huy Duc Do
* 
**/
public class SaveUnityMode : MonoBehaviour
{
    /// <summary>
    /// Used to save the selection of unity mode in the global variable unityMode
    /// </summary>
    public void Save()
    {
        GameObject.Find("Informations").GetComponent<SaveInformations>().unityMode = GameObject.Find("UnityMode").GetComponent<Toggle>().isOn;
    }
}
