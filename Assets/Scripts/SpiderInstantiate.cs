using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SpiderInstantiate : MonoBehaviour {

    public GameObject spiderPrefab;

     float spawnStartzeit = 0;

     float spawnIntervall = 0.5f;

     int timer = 0;

    float generalTimer = 0;

    int timerEnd;

    TextMesh spiderCount;
    TextMesh generalCount;

    float spawnDistance;
    
    TextMesh debug;
    int debugTimer = 0;

    Vector3 center;

    public bool testing = false;

	// Use this for initialization
	void Start () {
        //for (int i = 0; i < numObjects; i++)
        //{
        //    Vector3 position = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
        //    Instantiate(spiderPrefab, position, Quaternion.identity);
        //}

        //Zwischen spawnRadius in Meter und -spawnRadius in Meter

        InvokeRepeating("InstantiateObject", spawnStartzeit, spawnIntervall);

        //for (int i = 0; i < numObjects; i++)
        //{

        //    Vector3 pos = RandomCircle(center, spawnRadius);
        //    //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        //    Instantiate(spiderPrefab, pos, Quaternion.identity);
        //}

        if(GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            spiderCount = GameObject.Find("SpiderCount").GetComponent<TextMesh>();
            generalCount = GameObject.Find("GeneralCount").GetComponent<TextMesh>();
            debug = GameObject.Find("Debug").GetComponent<TextMesh>();
        }

        timerEnd = GameObject.Find("Informations").GetComponent<SaveInformations>().count;
    }

    // Update is called once per frame
    void Update () {
        center = transform.position;

        if(GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            generalTimer += Time.deltaTime;
            generalCount.text = "Zähler: " + (int)generalTimer;
        }
    }

    void InstantiateObject()
    {

        //Vector3 center = transform.position - new Vector3(0, -0.5f, 0);
        Vector3 pos = CreateRandomPoint(transform.position);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        var spider = Instantiate(spiderPrefab, pos, Quaternion.identity);
        spider.transform.localScale = Vector3.one * 0.05f;


        bool randomMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle;
        bool directMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle;
        bool bothMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().bothMovementToggle;


        if (randomMovementToggle)
        {
            spider.AddComponent<AddAgentRandMov>();
            spawnDistance = 3;
        }
        else if (directMovementToggle)
        {
            spider.AddComponent<AddAgent>();
            spawnDistance = 4;
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
            spawnDistance = 4;
        }

        timer++;

        if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            spiderCount.text = "Spinnenanzahl: " + timer;

            if (timer == timerEnd)
            {
                spiderCount.text = "Spinnenanzahl: max. " + timer;
            }
        }

        if (timer == timerEnd)
        {
            CancelInvoke();
        }

    }

    Vector3 RandomPoint(Vector3 center)
    {
        //float ang = Random.value * 360;
        //Vector3 pos;
        //pos.x = center.x + pointRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        ////pos.y = center.y + 0.1f;
        //pos.y = center.y - 1;
        //pos.z = center.z + pointRadius * Mathf.Cos(ang * Mathf.Deg2Rad);

        float screenX = center.x + Random.Range(-Camera.main.pixelWidth, Camera.main.pixelWidth);
        float screenY = center.y - 1 ;
        float screenZ = spawnDistance;
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(screenX, screenY, screenZ));

        return pos;
    }

    Vector3 CreateRandomPoint(Vector3 pos)
    {
        Vector3 randomPoint = RandomPoint(pos);
        //Vector3 randomPoint = pos + Random.insideUnitSphere * 2;


        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas);

        bool developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;
        if (NavMesh.SamplePosition(randomPoint, out hit, 2.0f, NavMesh.AllAreas) && developerMode)
        {
            debugTimer++;
            debug.text = "SamplePosition True: " + debugTimer;
        }

        if (testing)
        {
            GameObject randomPoint1 = Instantiate(Resources.Load("Position", typeof(GameObject))) as GameObject;
            randomPoint1.transform.position = randomPoint;

            GameObject spawnPoint = Instantiate(Resources.Load("WayPoint", typeof(GameObject))) as GameObject;
            spawnPoint.transform.position = hit.position;
        }

        

        return hit.position;
    }
}
