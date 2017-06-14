using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.AI;

/**
* This script enables the user to manually spawning and positioning objects with the HoloLens Tap Gesture
* 
* @author: Huy Duc Do
* 
**/
public class ManualPositioning : MonoBehaviour, IInputClickHandler
{
    public GameObject spiderPrefab;

    int spiderCount = 0;
    int spiderCountMax;

    float generalCounter = 0;

    public TextMesh spiderCountTextMesh;
    public TextMesh generalCountTextmesh;
    public TextMesh successfulledPositionTextMesh;
    int successfulledPositionCount = 0;

    bool developerMode;

    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to wait for an input, assign the global option variables to script variables and enables the developerMode 
    /// if the variable developerMode is true
    /// </summary>
    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);

        spiderCountTextMesh.text = "Spinnenanzahl: " + spiderCount;
        generalCountTextmesh.text = "Zähler: " + (int)generalCounter;
        successfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCount;

        spiderCountMax = SaveInformations.Instance.maxCount;

        developerMode = SaveInformations.Instance.developerMode;
    }

    /// <summary>
    /// Update is called once per frame
    /// Used to update the global timer if the variable developerMode is true
    /// </summary>
    private void Update()
    {
        if (developerMode)
        {
            generalCounter += Time.deltaTime;
            generalCountTextmesh.text = "Zeit: " + (int)generalCounter;
        }
    }

    /// <summary>
    /// Is performed if the HoloLens Tap Gesture is used
    /// Used to manually spawning and positioning an object and validates the spawning point
    /// Adds the movement script to the object and count the timer and counterGameObject
    /// </summary>
    public void SpawnObject()
    {
        GameObject spider = GameObject.Instantiate(spiderPrefab); 
        spider.transform.localScale = Vector3.one * 0.05f; 

        Vector3 spawningPoint = Camera.main.transform.position + Camera.main.transform.forward;
        NavMeshHit hit;
        NavMesh.SamplePosition(spawningPoint, out hit, 2.0f, NavMesh.AllAreas);

        if (NavMesh.SamplePosition(spawningPoint, out hit, 2.0f, NavMesh.AllAreas) && developerMode)
        {
            successfulledPositionCount++;
            successfulledPositionTextMesh.text = "SamplePosition True: " + successfulledPositionCount;
        }

        spider.transform.position = hit.position;

        spiderCount++;

        if (developerMode)
        {
            CountCounters();
        }
    }

    /// <summary>
    /// Used to count up the spider counterGameObject and stops if it reaches the maximum spider count
    /// </summary>
    private void CountCounters()
    {
        if (spiderCount == spiderCountMax)
        {
            spiderCountTextMesh.text = "Spinnenanzahl: max. " + spiderCount;
            CancelInvoke();
        }
        else
        {
            spiderCountTextMesh.text = "Spinnenanzahl: " + spiderCount;
        }
    }

    /// <summary>
    /// Used to spawn an object if an input come's in probably the HoloLens Tap Gesture and stops if it reaches the maximum spider count
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (spiderCount < spiderCountMax)
        {
            SpawnObject();
        }
    }
}

