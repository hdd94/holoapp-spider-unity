using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.AI;


/// <summary>
/// manager all measure tools here
/// </summary>
public class ManualPositioning : MonoBehaviour, IInputClickHandler
{

    public GameObject spiderPrefab;

    int timer = 0;
    int maxSpiderCount = 15;

    float generalTimer = 0;

    TextMesh spiderCount;
    TextMesh generalCount;

    GameObject position;

    bool developerMode;


    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);

        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;

        if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            spiderCount = GameObject.Find("SpiderCount").GetComponent<TextMesh>();
            generalCount = GameObject.Find("GeneralCount").GetComponent<TextMesh>();
        }
    }

    public void OnSelect()
    {
        //manager.AddPoint(LinePrefab, PointPrefab, TextPrefab);

        var spider = GameObject.Instantiate(spiderPrefab); // Create a cube
        spider.transform.localScale = Vector3.one * 0.05f; // Make the cube smaller
        //spider.transform.position = Camera.main.transform.position + Camera.main.transform.forward; // Start to drop it in front of the camera

        Vector3 point = Camera.main.transform.position + Camera.main.transform.forward;

        NavMeshHit hit;
        NavMesh.SamplePosition(point, out hit, 1.0f, NavMesh.AllAreas);

        spider.transform.position = hit.position;

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

            timer++;

        if (developerMode)
        {
            spiderCount.text = "Spinnenanzahl: " + timer;
        }

        if (developerMode && timer == 15)
        {
            
                spiderCount.text = "Spinnenanzahl: max. " + timer;
                CancelInvoke(); 
        }
        else if (timer == maxSpiderCount)
        {
                CancelInvoke();
        }
        

        //GameObject.Find("HoloLensCamera").GetComponent<SpiderInstantiate>().;
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (developerMode)
        {
            if (timer < 15)
            {
                OnSelect();
            }
        } else
        {
            if (timer < maxSpiderCount)
            {
                OnSelect();
            }
        }
    }

    private void Update()
    {
        if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            generalTimer += Time.deltaTime;
            generalCount.text = "Zeit: " + (int)generalTimer;
        }
    }
}

