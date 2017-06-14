using UnityEngine;


/**
* This script counts the start number down and if it reaches 0 it disappears
* 
* @author: Huy Duc Do
* 
**/
public class Countdown : MonoBehaviour {

    public float startNumber = 5;
    bool developerMode;
    public GameObject countdown;

    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to assign the global option variable to a script variable and write the variable startNumber in the textMesh
    /// </summary>
    void Start () {
        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;
        GetComponent<TextMesh>().text = startNumber.ToString();
        }

    /// <summary>
    /// Update is called once per frame
    /// Used to positioning the textmesh in front of the camera and count the start number down
    /// </summary>    
    void Update () {
    transform.position = Camera.main.transform.position + Camera.main.transform.forward * 4;

        if (!developerMode && startNumber > 0)
        {
            startNumber -= Time.deltaTime;
            GetComponent<TextMesh>().text = ((int)startNumber).ToString();
        } else
        {
            countdown.SetActive(false);
        }
	}
}
