using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

/**
* This script queries the global option variables and performs accordingly actions like start the developermode where it shows the set 
* options, spawn the objects randomly or manually and test on the Game Engine Unity
* 
* @author: Huy Duc Do
* 
**/
public class OptionsQuery : MonoBehaviour
{
    private string movementKindName;
    private bool developerMode;
    private bool unityMode;
    private bool manualPositioning;
    public GameObject counter;


    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to assign the global option variables to script variables and depends on the option variables the app starts in developer mode, 
    /// manually/randomly spawning and test in the game engine unity
    /// </summary>
    void Start () {


        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;
        unityMode = GameObject.Find("Informations").GetComponent<SaveInformations>().unityMode;
        manualPositioning = GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning;

        if (developerMode)
        {
            SetDeveloperMode();
        } else
        {
            GameObject.Find("DefaultCursor").SetActive(false);
        }

        if (manualPositioning)
        {
            GetComponent<ManualPositioning>().enabled = true;
        } else
        {
            GetComponent<SpiderInstantiate>().enabled = true;
        }

        if (unityMode)
        {
            gameObject.AddComponent<TestOnUnity>();
        }
    }

    /// <summary>
    /// Used to start the app in developer mode and shows the visual mesh of the spatial map and the set options
    /// </summary>
    private void SetDeveloperMode()
    {
        counter.SetActive(true);

        GameObject.Find("SpatialMapping").GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;

        string positioning = GameObject.Find("Positioning").GetComponent<TextMesh>().text;

        if (manualPositioning)
        {
            positioning = "Positionierung: Manuell";
        }
        else
        {
            positioning = "Positionierung: Zufall";
        }

        bool randomMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle;
        bool directMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle;
        bool bothMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().bothMovementToggle;

        if (randomMovementToggle)
        {
            movementKindName = "Zufall";
        }
        else if (directMovementToggle)
        {
            movementKindName = "Direkt";
        }
        else if (bothMovementToggle)
        {
            movementKindName = "Beides";
        }

        GameObject.Find("MovementKind").GetComponent<TextMesh>().text = "Bewegungsart: " + movementKindName;
        GameObject.Find("HoloLensCamera").GetComponent<SpiderInstantiate>().showDataPoints = true;
    }
}
