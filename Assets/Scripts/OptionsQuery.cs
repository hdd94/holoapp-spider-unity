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
        /// <summary>
        /// GameObject of counter 
        /// </summary>
        [Tooltip("GameObject of  counter")]
        public GameObject CounterGameObject;

        /// <summary>
        /// GameObject of countdown counter
        /// </summary>
        [Tooltip("GameObject of countdown counter")]
        public GameObject CountdownGameObject;

        /// <summary>
        /// GameObject of default cursor 
        /// </summary>
        [Tooltip("GameObject of default cursor")]
        public GameObject DefaultCursorGameObject;

        /// <summary>
        /// TextMeshObject of positioning
        /// </summary>
        [Tooltip("TextMeshObject of positioning")]
        public TextMesh PositioningTextMesh;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to start the app in developer mode depends on the option variable
        /// and if the app starts in Unity Editor add the TestOnUnity script
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
            GetComponent<SpiderInstantiate>().IsShowDataPoints = true;
            GameObject.Find("SpatialMapping").GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;

            if (SaveInformations.Instance.IsManualPositioning)
                PositioningTextMesh.text = "Positionierung: Manuell";
            else
                PositioningTextMesh.text = "Positionierung: Zufall";
        }
    }
}
