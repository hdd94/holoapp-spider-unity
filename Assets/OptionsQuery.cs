using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsQuery : MonoBehaviour {

    private bool developerMode;
    private bool unityMode;
    private bool manualPositioning;

    void Start () {

        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;
        unityMode = GameObject.Find("Informations").GetComponent<SaveInformations>().unityMode;
        manualPositioning = GameObject.Find("Informations").GetComponent<SaveInformations>().manualPositioning;

        if (developerMode)
        {
        }

        if (unityMode)
        {
            gameObject.AddComponent<TestOnUnity>();
        }

        if (manualPositioning)
        {
            GetComponent<ManualPositioning>().enabled = true;
        } else
        {
            GetComponent<SpiderInstantiate>().enabled = true;
        }

    }
}
