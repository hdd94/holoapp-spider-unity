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
    public class SpiderInstantiate : MonoBehaviour
    {
        public TextMesh spiderCountTextMesh;
        public TextMesh generalCountTextmesh;
        public TextMesh successfulledPositionTextMesh;
        public GameObject spiderPrefab;
        public bool IsShowDataPoints = false;

        private float spawningStartTime = 0.5f;
        private float spawningIntervalTime = 0.5f;
        private float spawningDistance = 4f;

        private int spiderCount = 0, successfulledPositionCountNumber = 0;
        private float generalCountNumber = 0;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to spawn objects in a set interval time with developer mode if set
        /// </summary>
        private void Start()
        {
            InvokeRepeating("InstantiateObject", spawningStartTime, spawningIntervalTime);

            if (SaveInformations.Instance.IsDeveloperMode)
            {
                spiderCountTextMesh.text = "Spinnenanzahl: " + spiderCount;
                successfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCountNumber;
            }
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
                generalCountTextmesh.text = "Zähler: " + (int)generalCountNumber;
            }
        }

        /// <summary>
        /// Used to spawn objects in random positions and add them a movement script
        /// Stop spawning if the number reaches the maximum object Count
        /// </summary>
        private void InstantiateObject()
        {
            Vector3 randomPosition;
            do
                randomPosition = RandomPosition(transform.position);
            while
                (!IsRandomPositionValid(randomPosition));

            var spider = Instantiate(spiderPrefab, randomPosition, Quaternion.identity);
            //spider.transform.localScale = Vector3.one * 0.05f;

            if (IsValidate && SaveInformations.Instance.IsDeveloperMode)
            {
                successfulledPositionCountNumber++;
                successfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCountNumber;
            }

            if (IsShowDataPoints)
                ShowDataPoints(hit.position);

            spiderCount++;

            if (SaveInformations.Instance.IsDeveloperMode)
                CountCounters();

            if (spiderCount == SaveInformations.Instance.Count)
                CancelInvoke();
        }
        
        private void InstantiateObject1()
        {
            NavMeshHit hit;
            do
                hit = ValidatedRandomPosition(transform.position);
            while (hit.hit);

            var spider = Instantiate(spiderPrefab, hit.position, Quaternion.identity);

            // !!!!!!!!!!!!! Hier weiterschreiben, nähmlich wie es nach erfolgreichen Spawnen weiter geht (Timer hoch zählen)

            //Vector3 randomPosition = RandomPosition(transform.position);
            //Vector3 validatedRandomPosition = ValidatedRandomPosition(randomPosition);
        }

        /// <summary>
        /// Used to Count up the spider Count
        /// </summary>
        private void CountCounters()
        {
            spiderCountTextMesh.text = "Spinnenanzahl: " + spiderCount;

            if (spiderCount == SaveInformations.Instance.Count)
                spiderCountTextMesh.text = "Spinnenanzahl: max. " + spiderCount;
        }

        /// <summary>
        /// Used to return an random point in the current view of the camera
        /// </summary>
        /// <param name="position">camera position</param> 
        /// <returns>random point</returns>
        private NavMeshHit ValidatedRandomPosition(Vector3 position)
        {
            float screenX = position.x + Random.Range(-Camera.main.pixelWidth, Camera.main.pixelWidth);
            float screenY = position.y - 1;
            float screenZ = spawningDistance;
            Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, screenZ));

            NavMeshHit hit;
            NavMesh.SamplePosition(randomPosition, out hit, 3.0f, NavMesh.AllAreas);

            return hit;
        }

        /// <summary>
        /// Used to IsValidate if it is able to spawn an object on the given random point and queries if it should show the data points
        /// </summary>
        /// <param name="pos">given random point</param> 
        /// <returns>nearest validated point to the given random point</returns> 
        private bool IsRandomPositionValid(Vector3 randomPosition)
        {
            NavMeshHit hit;
            bool IsValidate = NavMesh.SamplePosition(randomPosition, out hit, 5.0f, NavMesh.AllAreas);

            return IsValidate;
        }

        //private Vector3 ValidatedRandomPosition(Vector3 randomPosition)
        //{
        //    NavMeshHit hit;
        //    NavMesh.SamplePosition(randomPosition, out hit, 5.0f, NavMesh.AllAreas);

        //    return hit.position;
        //}

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