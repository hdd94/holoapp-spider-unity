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

    float globalTimer = 0;

    TextMesh spiderCountText;
    TextMesh globalTimerText;

    TextMesh successfulledPosition;
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

        spiderCountMax = GameObject.Find("Informations").GetComponent<SaveInformations>().maxCount;

        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;

        if (developerMode)
        {
            spiderCountText = GameObject.Find("SpiderCount").GetComponent<TextMesh>();
            globalTimerText = GameObject.Find("GeneralCount").GetComponent<TextMesh>();
            successfulledPosition = GameObject.Find("Debug").GetComponent<TextMesh>();
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// Used to update the global timer if the variable developerMode is true
    /// </summary>
    private void Update()
    {
        if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            globalTimer += Time.deltaTime;
            globalTimerText.text = "Zeit: " + (int)globalTimer;
        }
    }

    /// <summary>
    /// Is performed if the HoloLens Tap Gesture is used
    /// Used to manually spawning and positioning an object and validates the spawning point
    /// Adds the movement script to the object and count the timer and counter
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
            successfulledPosition.text = "SamplePosition True: " + successfulledPositionCount;
        }

        spider.transform.position = hit.position;

        spiderCount++;

        AddMovementScript(spider);

        if (developerMode)
        {
            CountCounters();
        }
    }

    /// <summary>
    /// Used to query the options and add accordingly a movement script
    /// The movement scripts are directly, randomly and both of these movements
    /// </summary>
    /// <param name="spider"></param> spider gameobject 
    private void AddMovementScript(GameObject spider)
    {
        bool randomMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle;
        bool directMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle;
        bool bothMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().bothMovementToggle;

        if (randomMovementToggle)
        {
            spider.AddComponent<AddAgentRandMov>();
        }
        else if (directMovementToggle)
        {
            spider.AddComponent<AddAgent>();
        }
        else if (bothMovementToggle)
        {
            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0) // Zufällig
            {
                spider.AddComponent<AddAgentRandMov>();
            }
            else if (randomNumber == 1) // Direkt
            {
                spider.AddComponent<AddAgent>();
            }
        }
    }

    /// <summary>
    /// Used to count up the spider counter and stops if it reaches the maximum spider count
    /// </summary>
    private void CountCounters()
    {
        if (spiderCount == spiderCountMax)
        {
            spiderCountText.text = "Spinnenanzahl: max. " + spiderCount;
            CancelInvoke();
        }
        else
        {
            spiderCountText.text = "Spinnenanzahl: " + spiderCount;
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

