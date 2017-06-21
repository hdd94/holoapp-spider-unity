using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

/**
* This script queries the global option variables and performs accordingly actions like start the developermode where it shows the set 
* options, spawn the objects randomly or manually and test on the Game Engine Unity
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class OptionsQuery : MonoBehaviour
    {
        public GameObject CounterGameObject;
        public GameObject CountdownGameObject;
        public GameObject DefaultCursorGameObject;
        public TextMesh PositioningTextMesh;
        public SpiderInstantiate SpiderInstantiateScript;
        public ManualPositioning ManualPositioningScript;

        private string movementKindName;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to assign the global option variables to script variables and depends on the option variables the app starts in developer mode, 
        /// manually/randomly spawning and test in the game engine unity
        /// </summary>
        private void Start()
        {
            if (SaveInformations.Instance.IsDeveloperMode)
                SetDeveloperMode();
            else
            {
                DefaultCursorGameObject.SetActive(false);
                if (!SaveInformations.Instance.IsManualPositioning)
                    CountdownGameObject.SetActive(true);
            }

            if (SaveInformations.Instance.IsManualPositioning)
                GetComponent<ManualPositioning>().enabled = true;
            else
                GetComponent<SpiderInstantiate>().enabled = true;

#if UNITY_EDITOR
            gameObject.AddComponent<TestOnUnity>();
#endif
        }

        /// <summary>
        /// Used to start the app in developer mode and shows the visual mesh of the spatial map and the set options
        /// </summary>
        private void SetDeveloperMode()
        {
            CounterGameObject.SetActive(true);
            SpiderInstantiateScript.IsShowDataPoints = true;
            GameObject.Find("SpatialMapping").GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;

            string positioningText;
            if (SaveInformations.Instance.IsManualPositioning)
                positioningText = "Positionierung: Manuell";
            else
                positioningText = "Positionierung: Zufall";
            PositioningTextMesh.text = positioningText;
        }
    }
}
