using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderInstantiate : MonoBehaviour {

    public GameObject spiderPrefab;

     float spawnRadius = 0.5f;

     float spawnStartzeit = 8;

     float spawnIntervall = 2;

     int timer = 0;

    float generalTimer = 0;

    int timerEnd = 3;

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

        spiderCount = GameObject.Find("SpiderCount").GetComponent<TextMesh>();

        generalCount = GameObject.Find("GeneralCount").GetComponent<TextMesh>();

    }
	
	// Update is called once per frame
	void Update () {
        center = transform.position;

        generalTimer += Time.deltaTime;
        generalCount.text = "Zähler: " + (int)generalTimer;
    }

    void InstantiateObject()
    {
        Vector3 pos = RandomCircle(center, spawnRadius);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        var spider = Instantiate(spiderPrefab, pos, Quaternion.identity);
        spider.transform.localScale = Vector3.one * 0.05f;       
        print(spider.transform.position);

        timer++;

        spiderCount.text = "Spinnenanzahl: " + timer;

        if (timer == timerEnd)
        {
            spiderCount.text = "Spinnenanzahl: max";
            CancelInvoke();
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
