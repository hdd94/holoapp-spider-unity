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
    public GameObject counterGameObject;
    public GameObject countdownGameObject;
    public GameObject defaultCursor;
    public TextMesh positioningTextMesh;
    public SpiderInstantiate spiderInstantiateScript;
    public ManualPositioning manualPositioningScript;

    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to assign the global option variables to script variables and depends on the option variables the app starts in developer mode, 
    /// manually/randomly spawning and test in the game engine unity
    /// </summary>
    void Start () {

        developerMode = SaveInformations.Instance.developerMode;
        unityMode = SaveInformations.Instance.unityMode;
        manualPositioning = SaveInformations.Instance.manualPositioning;

        if (developerMode)
        {
            SetDeveloperMode();
        } else
        {
            defaultCursor.SetActive(false);
            if(!manualPositioning)
            {
                countdownGameObject.SetActive(true);
            }
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
        counterGameObject.SetActive(true);

        GameObject.Find("SpatialMapping").GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;

        string positioning;

        if (manualPositioning)
        {
            positioning = "Positionierung: Manuell";
        }
        else
        {
            positioning = "Positionierung: Zufall";
        }

        positioningTextMesh.text = positioning;

        spiderInstantiateScript.showDataPoints = true;
    }
}
