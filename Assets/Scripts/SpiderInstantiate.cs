using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/**
* This script enables to spawn objects randomly with validated spawning position in a set interval time with developer mode funtions 
* like spider CounterGameObject, global timer and showed dataPoints
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class SpiderInstantiate: MonoBehaviour, IInputClickHandler
    {
        /// <summary>
        /// GameObject of spider prefab
        /// </summary>
        [Tooltip("GameObject of spider prefab")]
        public GameObject SpiderPrefabGameObject;

        /// <summary>
        /// TextMeshObject of spider counter 
        /// </summary>
        [Tooltip("TextMeshObject of spider counter")]
        public TextMesh SpiderCountTextMesh;

        /// <summary>
        /// TextmeshObject of general counter
        /// </summary>
        [Tooltip("TextmeshObject of general counter")]
        public TextMesh GeneralCountTextmesh;

        /// <summary>
        /// Bool variable if dataPoint should be showed
        /// </summary>
        [Tooltip("Bool variable if dataPoint should be showed")]
        public bool IsShowDataPoints = false;

        private float _spawningDistance = 3;
        private float _generalCountNumber = 0;
        private int _spiderCountNumber = 0;
        private float _spawningStartTime = 0.5f;
        private float _spawningIntervalTime = 0.5f;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to query if spider spawning should be manual or random
        /// </summary>
        private void Start()
        {
            if (SaveInformations.Instance.IsManualPositioning)
                InputManager.Instance.AddGlobalListener(gameObject);
            else
                InvokeRepeating("InstantiateSpider", _spawningStartTime, _spawningIntervalTime);
        }

        /// <summary>
        /// Used to be performed by click event
        /// </summary>
        public void OnInputClicked(InputClickedEventData eventData)
        {
            InstantiateSpider();
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to update the global timer if the variable IsDeveloperMode is true
        /// </summary>
        private void Update()
        {
            if (SaveInformations.Instance.IsDeveloperMode)
            {
                _generalCountNumber += Time.deltaTime;
                GeneralCountTextmesh.text = "Zähler: " + (int)_generalCountNumber;
            }
        }

        /// <summary>
        /// Used to spawn objects in random positions which are validated in the background through a coroutine
        /// This routine will be given an anonym method which use the validated position to instantiate a spider in a random size
        /// The anonym method queries if dataPoint should be showed and count up counters if developerMode is active 
        /// Stop instantiating if spider number reaches the maximum spider Count
        /// </summary>
        protected void InstantiateSpider()
        {
            StartCoroutine(GetSpawnPosition( (spawnPosition) =>
            {
                var spider = Instantiate(SpiderPrefabGameObject, spawnPosition, Quaternion.identity);
                _spiderCountNumber++;

                spider.transform.localScale *= UnityEngine.Random.Range(0.6f, 1.4f);

                if (IsShowDataPoints)
                    ShowDataPoints(spawnPosition);
                if (SaveInformations.Instance.IsDeveloperMode)
                    CountCounters();
                if (_spiderCountNumber == SaveInformations.Instance.Count)
                    CancelInvoke();
            })
            );
        }

        /// <summary>
        /// Used to search for an random position until a validated position is found and performs afterwards the anonym method
        /// </summary>
        /// <param name="callback">anonym method which will be peformed when a validated position is found</param>
        /// <returns>IEnumerator which is null</returns>
        private IEnumerator GetSpawnPosition(Action<Vector3> callback)
        {
            Vector3 validatedPosition;
            while (!GetValidatedPosition(out validatedPosition)) ;
            callback(validatedPosition);
            yield return null;
        }

        /// <summary>
        /// Used to return a bool variable if position can be placed on a spatial mesh
        /// Creates a random point in the front view of camera and search a nearest point on the spatial mesh 
        /// </summary>
        /// <param name="position">random position variable which is referenced</param>
        /// <returns>bool variable if position can be placed on a spatial mesh</returns>
        private bool GetValidatedPosition(out Vector3 position)
        {
            float screenX = transform.position.x + UnityEngine.Random.Range(-Camera.main.pixelWidth, Camera.main.pixelWidth);
            float screenY = transform.position.y - 1;
            float screenZ = _spawningDistance;
            var randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, screenZ));

            NavMeshHit hit;
            var result = NavMesh.SamplePosition(randomPosition, out hit, 3.0f, NavMesh.AllAreas);
            position = hit.position;

            return result;
        }

        /// <summary>
        /// Used to count up the spider count and show max count if it reaches max spider count
        /// </summary>
        private void CountCounters()
        {
            SpiderCountTextMesh.text = "Spinnenanzahl: " + _spiderCountNumber;

            if (_spiderCountNumber == SaveInformations.Instance.Count)
                SpiderCountTextMesh.text = "Spinnenanzahl: max. " + _spiderCountNumber;
        }

        /// <summary>
        /// Used to show data points like spawn position and destination position marked as cube
        /// </summary>
        /// <param name="hitPosition">Spawnpoint of the spider</param>
        private void ShowDataPoints(Vector3 hitPosition)
        {
            Instantiate(Resources.Load<GameObject>("SpawningPosition"), hitPosition, Quaternion.identity);
        }
    }
}