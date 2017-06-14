using UnityEngine;
using UnityEngine.AI;

/**
* This script enables to spawn objects randomly with validated spawning position in a set interval time with developer mode funtions 
* like spider counterGameObject, global timer and showed dataPoints
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
    float generalCounter = 0;

    public TextMesh spiderCountTextMesh;
    public TextMesh generalCountTextmesh;
    public TextMesh successfulledPositionTextMesh;
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

        spiderCountTextMesh.text = "Spinnenanzahl: " + spiderCount;
        generalCountTextmesh.text = "Zähler: " + (int)generalCounter;
        successfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCount;

        spiderCountMax = GameObject.Find("Informations").GetComponent<SaveInformations>().count;
    }

    /// <summary>
    /// Update is called once per frame
    /// Used to update the global timer if the variable developerMode is true
    /// </summary>
    void Update () {

        if(developerMode)
        {
            generalCounter += Time.deltaTime;
            generalCountTextmesh.text = "Zähler: " + (int)generalCounter;
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
        spiderCountTextMesh.text = "Spinnenanzahl: " + spiderCount;

        if (spiderCount == spiderCountMax)
        {
            spiderCountTextMesh.text = "Spinnenanzahl: max. " + spiderCount;
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
            successfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCount;
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
