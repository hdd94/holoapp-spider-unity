using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //       int areaMask = 1 << NavMesh.GetAreaFromName("Walkable");
    //       NavMeshHit hit;
    //       NavMesh.Raycast(transform.position, transform.position + Vector3.down , out hit , );
    //       if (hit.hit && hit.mask == NavMesh.GetAreaFromName("Walkable"))
    //           Debug.Log("True");


    //       //Ray ray = new Ray(transform.position, Vector3.down);
    //       //Debug.DrawRay(ray.origin, ray.direction, Color.cyan);
    //       Debug.Log(transform.position);
    //       Debug.DrawLine(transform.position, transform.position + Vector3.down , Color.cyan);

    //       //Debug.Log(Physics.Raycast(ray));
    //   }

    public float range = 2.0f;

    private void Start()
    {
       
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            //    Debug.Log(result);
            return true;
        }
        result = Vector3.zero;
        return false;
    }

    void Update()
    {
        Vector3 point;
        if (RandomPoint(transform.position, range, out point))
        {
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
        }
    }

    Vector3 CreateRandomPoint(Vector3 pos, float range, out Vector3 result)
    {
        Vector3 randomPoint = pos + Random.insideUnitSphere * range;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);
        result = hit.position;
        return result;
    }
}
