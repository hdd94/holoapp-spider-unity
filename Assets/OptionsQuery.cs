using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsQuery : MonoBehaviour {

    private bool randomMovementToggle;
    private bool directMovementToggle;
    private string movementKindName;
    private bool developerMode;
    private bool unityMode;
    private bool manualPositioning;
    public GameObject counter;

    void Start () {


        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;
        manualPositioning = GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning;
        unityMode = GameObject.Find("Informations").GetComponent<SaveInformations>().unityMode;
        
        if (developerMode)
        {
            counter.SetActive(true);
            GameObject.Find("SpatialMapping").GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;

            if (manualPositioning)
            {
                GameObject.Find("Positioning").GetComponent<TextMesh>().text = "Positionierung: Manuell";
            }
            else
            {
                GameObject.Find("Positioning").GetComponent<TextMesh>().text = "Positionierung: Zufall";
            }

            //GameObject.Find("SpatialMapping").GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;
            // Timer anzeigen
            // Spinnenpositionierung anzeigen mittels blauen Strahl
            // SpatialMesh anzeigen

            bool randomMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle;
            bool directMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle;

            if (randomMovementToggle)
            {
                movementKindName = "Zufall";
            }
            else if (directMovementToggle)
            {
                movementKindName = "Direkt";
            }

            GameObject.Find("MovementKind").GetComponent<TextMesh>().text = "Bewegungsart: " + movementKindName;
            GameObject.Find("HoloLensCamera").GetComponent<SpiderInstantiate>().testing = true;
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
}
