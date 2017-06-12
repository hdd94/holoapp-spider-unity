using UnityEngine;
using UnityEngine.UI;

/**
* This script updates the count if the spider counter changes
* 
* @author: Huy Duc Do
* 
**/
public class UpdateCount : MonoBehaviour
{
    /// <summary>
    /// Update is called once per frame
    /// Used to update the count if the spider counter changes
    /// </summary>
    private void Update()
    {
        GameObject.Find("lblCountMain").GetComponent<Text>().text = "Spinnenanzahl: " + GameObject.Find("Informations").GetComponent<SaveInformations>().count.ToString();
    }
}
