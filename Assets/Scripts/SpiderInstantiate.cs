using UnityEngine;
using UnityEngine.AI;

/**
* This script enables to spawn objects randomly with validated spawning position in a set interval time with developer mode funtions 
* like spider counter, global timer and showed dataPoints
* 
* @author: Huy Duc Do
* 
**/
public class SpiderInstantiate : MonoBehaviour
{
    public GameObject spiderPrefab;

    float spawningStartTime = 0.5f;
    float spawningIntervalTime = 0.5f;
    float spawningDistance = 4f;

    int spiderCount = 0;
    int spiderCountMax;
    float globalTimer = 0;

    TextMesh spiderCountText;
    TextMesh globalTimerText;
    
    TextMesh successfulledPosition;
    int successfulledPositionCount = 0;

    public bool showDataPoints = false;
    bool developerMode;
    bool unityMode;

    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to spawn objects in a set interval time with developer mode if set
    /// </summary>
    void Start () {
        InvokeRepeating("InstantiateObject", spawningStartTime, spawningIntervalTime);

        unityMode = SaveInformations.Instance.unityMode;
        developerMode = SaveInformations.Instance.developerMode;

        if (developerMode)
        {
            spiderCountText = GameObject.Find("SpiderCount").GetComponent<TextMesh>();
            globalTimerText = GameObject.Find("GeneralCount").GetComponent<TextMesh>();
            successfulledPosition = GameObject.Find("Debug").GetComponent<TextMesh>();
        }

        spiderCountMax = GameObject.Find("Informations").GetComponent<SaveInformations>().count;
    }

    /// <summary>
    /// Update is called once per frame
    /// Used to update the global timer if the variable developerMode is true
    /// </summary>
    void Update () {

        if(developerMode)
        {
            globalTimer += Time.deltaTime;
            globalTimerText.text = "Zähler: " + (int)globalTimer;
        }
    }

    /// <summary>
    /// Used to spawn objects in random positions and add them a movement script
    /// Stop spawning if the number reaches the maximum object count
    /// </summary>
    void InstantiateObject()
    {
        Vector3 randomPosition = ValidateRandomPoint(transform.position);
        var spider = Instantiate(spiderPrefab, randomPosition, Quaternion.identity);
        spider.transform.localScale = Vector3.one * 0.05f;


        bool randomMovementToggle = SaveInformations.Instance.randomMovementToggle;
        bool directMovementToggle = SaveInformations.Instance.directMovementToggle;
        bool bothMovementToggle = SaveInformations.Instance.bothMovementToggle;


        if (randomMovementToggle)
        {
            spider.AddComponent<AddAgentRandMov>();
            spawningDistance = 3;
        }
        else if (directMovementToggle)
        {
            spider.AddComponent<AddAgent>();
            spawningDistance = 4;
        }
        else if (bothMovementToggle)
        {
            spawningDistance = 4;

            var randomNumber = Random.Range(0, 2);
            if (randomNumber == 0) // Zufällig
            {
                spider.AddComponent<AddAgentRandMov>();
            }
            else if (randomNumber == 1) // Direkt
            {
                spider.AddComponent<AddAgent>();
            }
        }

        spiderCount++;

        if (developerMode)
        {
            CountCounters();
        }

        if (spiderCount == spiderCountMax)
        {
            CancelInvoke();
        }
    }

    /// <summary>
    /// Used to count up the spider count
    /// </summary>
    private void CountCounters()
    {
        spiderCountText.text = "Spinnenanzahl: " + spiderCount;

        if (spiderCount == spiderCountMax)
        {
            spiderCountText.text = "Spinnenanzahl: max. " + spiderCount;
        }
    }

    /// <summary>
    /// Used to return an random point in the current view of the camera
    /// </summary>
    /// <param name="center"></param> camera position
    /// <returns></returns> random point 
    Vector3 RandomPoint(Vector3 center)
    {
        float screenX = center.x + Random.Range(-Camera.main.pixelWidth, Camera.main.pixelWidth);
        float screenY = center.y - 1;
        float screenZ = spawningDistance;
        Vector3 randomPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, screenZ));

        return randomPosition;
    }

    /// <summary>
    /// Used to validate if it is able to spawn an object on the given random point and queries if it should show the data points
    /// </summary>
    /// <param name="pos"></param> given random point
    /// <returns></returns> nearest validated point to the given random point
    Vector3 ValidateRandomPoint(Vector3 pos)
    {
        Vector3 randomPoint = RandomPoint(pos);

        NavMeshHit hit;
        bool validate = NavMesh.SamplePosition(randomPoint, out hit, 3.0f, NavMesh.AllAreas);

        if (validate && developerMode)
        {
            successfulledPositionCount++;
            successfulledPosition.text = "SamplePosition True: " + successfulledPositionCount;
        }

        if (showDataPoints)
        {
            ShowDataPoints(randomPoint, hit);
        }
        
        return hit.position;
    }

    /// <summary>
    /// Used to show data points like spawn position and destination position marked as cube
    /// </summary>
    /// <param name="randomPoint"></param>
    /// <param name="hit"></param>
    private void ShowDataPoints(Vector3 randomPoint, NavMeshHit hit)
    {
        GameObject spawnPoint = Instantiate(Resources.Load("SpawningPosition", typeof(GameObject))) as GameObject;
        spawnPoint.transform.position = hit.position;
        Destroy(spawnPoint.GetComponent<BoxCollider>());
    }
}
