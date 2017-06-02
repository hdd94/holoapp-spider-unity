using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderInstantiate : MonoBehaviour {

    public GameObject spiderPrefab;

     float pointRadius = 1;

     float spawnStartzeit = 8;

     float spawnIntervall = 2;

     int timer = 0;

    float generalTimer = 0;

    int timerEnd;

    TextMesh spiderCount;
    TextMesh generalCount;

    Vector3 center;

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
        Vector3 center = transform.position - new Vector3(0, -0.5f, 0);
        Vector3 pos = CreateRandomPoint(transform.position);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        var spider = Instantiate(spiderPrefab, pos, Quaternion.identity);
        spider.transform.localScale = Vector3.one * 0.05f;

        bool randomMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle;
        bool directMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle;

        if (randomMovementToggle)
        {
            spider.AddComponent<AddAgentRandMov>();
        }
        else if (directMovementToggle)
        {
            spider.AddComponent<AddAgent>();
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
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + pointRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + 0.1f;
        pos.z = center.z + pointRadius * Mathf.Cos(ang * Mathf.Deg2Rad);


        return pos;
    }

    Vector3 CreateRandomPoint(Vector3 pos)
    {
        //Vector3 randomPoint = pos + Random.insideUnitSphere * pointRadius;
        Vector3 randomPoint = RandomPoint(pos);
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);
        return hit.position;
    }
}
