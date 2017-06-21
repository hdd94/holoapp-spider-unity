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
        public GameObject SpiderPrefabGameObject;
        public TextMesh SpiderCountTextMesh;
        public TextMesh GeneralCountTextmesh;
        public bool IsShowDataPoints = false;

        private float spawningDistance = 4;
        private float generalCountNumber = 0;
        private int spiderCountNumber = 0;
        private float _spawningStartTime = 0.5f;
        private float _spawningIntervalTime = 0.5f;

        private void Start()
        {
            if (SaveInformations.Instance.IsManualPositioning)
                InputManager.Instance.AddGlobalListener(gameObject);
            else
                InvokeRepeating("InstantiateObject", _spawningStartTime, _spawningIntervalTime);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            InstantiateObject();
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
                GeneralCountTextmesh.text = "Zähler: " + (int)generalCountNumber;
            }
        }

        /// <summary>
        /// Used to spawn objects in random positions and add them a movement script
        /// Stop spawning if the number reaches the maximum object Count
        /// </summary>
        protected void InstantiateObject()
        {
            StartCoroutine(GetSpawnPosition((spawnPosition) =>
            {
                var spider = Instantiate(SpiderPrefabGameObject, spawnPosition, Quaternion.identity);
                spiderCountNumber++;

                //int randomNumber = Random.Range(0, 3);
                //switch (randomNumber)
                //{
                //    case 0: // klein
                //        spider.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
                //        break;
                //    case 1: // normal
                //        break;
                //    case 2: // groß
                //        spider.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
                //        break;
                //}

                if (IsShowDataPoints)
                    ShowDataPoints(spawnPosition);
                if (SaveInformations.Instance.IsDeveloperMode)
                    CountCounters();
                if (spiderCountNumber == SaveInformations.Instance.Count)
                    CancelInvoke();
            }));

        }

        public IEnumerator GetSpawnPosition(Action<Vector3> callback)
        {
            Vector3 validatedPosition;
            while (!GetValidatedPosition(out validatedPosition)) ;
            callback(validatedPosition);
            yield return null;
        }

        /// <summary>
        /// Used to Count up the spider Count
        /// </summary>
        private void CountCounters()
        {
            SpiderCountTextMesh.text = "Spinnenanzahl: " + spiderCountNumber;

            if (spiderCountNumber == SaveInformations.Instance.Count)
                SpiderCountTextMesh.text = "Spinnenanzahl: max. " + spiderCountNumber;
        }

        /// <summary>
        /// Used to show data points like spawn position and destination position marked as cube
        /// </summary>
        /// <param name="hitPosition">Spawnpoint of the spider</param>
        private void ShowDataPoints(Vector3 hitPosition)
        {
            Instantiate(Resources.Load<GameObject>("SpawningPosition"), hitPosition, Quaternion.identity);
        }

        private bool GetValidatedPosition(out Vector3 position)
        {
            float screenX = transform.position.x + UnityEngine.Random.Range(-Camera.main.pixelWidth, Camera.main.pixelWidth);
            float screenY = transform.position.y - 1;
            float screenZ = spawningDistance;

            var randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, screenZ));

            NavMeshHit hit;
            var result = NavMesh.SamplePosition(randomPosition, out hit, 3.0f, NavMesh.AllAreas);
            position = hit.position;

            return result;
        }
    }
}