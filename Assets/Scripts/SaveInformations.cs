using UnityEngine;

/**
* This script saves all option variables and makes them global
* 
* @author: Huy Duc Do
* 
**/
public class SaveInformations : MonoBehaviour
{
    public int maxCount;
    public int count;
    public bool randomMovementToggle;
    public bool directMovementToggle;
    public bool bothMovementToggle;
    public bool developerMode;
    public bool manualPositioning;
    public bool unityMode;

    /// <summary>
    /// Called on start independently if the script is enabled/disabled
    /// Don't destroy this script after loading a new scene
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
