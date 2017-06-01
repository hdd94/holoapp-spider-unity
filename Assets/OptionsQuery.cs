using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsQuery : MonoBehaviour {

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
            // Timer anzeigen
            // Spinnenpositionierung anzeigen mittels blauen Strahl
            // SpatialMesh anzeigen
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
