using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.AI;

/**
* This script enables the user to manually spawning and positioning objects with the HoloLens Tap Gesture
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class ManualPositioning : MonoBehaviour, IInputClickHandler
    {
        public GameObject SpiderPrefabGameObject;
        public TextMesh SpiderCountTextMesh;
        public TextMesh GeneralCountTextmesh;
        public TextMesh SuccessfulledPositionTextMesh;

        private int spiderCountNumber = 0, successfulledPositionCountNumber = 0;
        private float generalCountNumber = 0;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to assign the global option variables to script variables and enables the IsDeveloperMode 
        /// if the variable IsDeveloperMode is true
        /// </summary>
        private void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);

            SpiderCountTextMesh.text = "Spinnenanzahl: " + spiderCountNumber;
            SuccessfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCountNumber;
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to update the global timer if the variable IsDeveloperMode is true
        /// </summary>
        private void Update()
        {
            if (SaveInformations.Instance.IsDeveloperMode)
            {
                generalCountNumber += Time.deltaTime;
                GeneralCountTextmesh.text = "Zeit: " + (int)generalCountNumber;
            }
        }

        /// <summary>
        /// Is performed if the HoloLens Tap Gesture is used
        /// Used to manually spawning and positioning an object and validates the spawning point
        /// Adds the movement script to the object and Count the timer and CounterGameObject
        /// </summary>
        public void SpawnObject()
        {
            GameObject spiderGameObject = GameObject.Instantiate(SpiderPrefabGameObject);

            Vector3 spawningPosition = Camera.main.transform.position + Camera.main.transform.forward;
            NavMeshHit hit;
            NavMesh.SamplePosition(spawningPosition, out hit, 2.0f, NavMesh.AllAreas);

            if (NavMesh.SamplePosition(spawningPosition, out hit, 2.0f, NavMesh.AllAreas) && SaveInformations.Instance.IsDeveloperMode)
            {
                successfulledPositionCountNumber++;
                SuccessfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCountNumber;
            }

            spiderGameObject.transform.position = hit.position;

            spiderCountNumber++;

            if (SaveInformations.Instance.IsDeveloperMode)
                CountCounters();
        }

        /// <summary>
        /// Used to Count up the spiderGameObject CounterGameObject and stops if it reaches the maximum spiderGameObject Count
        /// </summary>
        private void CountCounters()
        {
            if (spiderCountNumber == SaveInformations.Instance.MaxCount)
            {
                SpiderCountTextMesh.text = "Spinnenanzahl: max. " + spiderCountNumber;
                CancelInvoke();
            }
            else
                SpiderCountTextMesh.text = "Spinnenanzahl: " + spiderCountNumber;
        }

        /// <summary>
        /// Used to spawn an object if an input come's in probably the HoloLens Tap Gesture and stops if it reaches the maximum spiderGameObject Count
        /// </summary>
        /// <param name="eventData">Description of input event</param>
        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (spiderCountNumber < SaveInformations.Instance.MaxCount)
                SpawnObject();
        }
    }
}
