using UnityEngine;

/**
* This script counts the start number down and if it reaches 0 it disappears
* 
* @author: Huy Duc Do
* 
**/
public class Countdown : MonoBehaviour
{
    public float startNumber = 5;
    bool developerMode;

    public GameObject countdown;
    public TextMesh countDownTextMesh;


    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to assign the global option variable to a script variable and write the variable startNumber in the textMesh
    /// </summary>
    void Start () {
        developerMode = SaveInformations.Instance.developerMode;
        countDownTextMesh.text = startNumber.ToString();
        }

    /// <summary>
    /// Update is called once per frame
    /// Used to positioning the textmesh in front of the camera and count the start number down
    /// </summary>    
    void Update () {
        if (!developerMode && startNumber > 0)
        {
            startNumber -= Time.deltaTime;
            countDownTextMesh.text = ((int)startNumber).ToString();
        } else
        {
            countdown.SetActive(false);
        }
    }
}
