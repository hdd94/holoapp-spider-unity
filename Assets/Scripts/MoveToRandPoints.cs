// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveToRandPoints : MonoBehaviour
{
    Animator anim;

    NavMeshAgent agent;

    Vector3 randomPosition;

    Vector3 direction;

    Quaternion rotation;

    float pointRadius = 1;

    float distance;

    GameObject wayPoint;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
            agent.speed = 0.2f;
        }

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        //randomPosition = RandomPoint(transform.position);

        //while (CheckIfOnLayer(randomPosition) == false)
        //{
        //    randomPosition = RandomPoint(transform.position);
        //}

        randomPosition = CreateRandomPoint(transform.position);

        if(GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            CreatePointCube(randomPosition);
        }
    }

    private void Update()
    {
        agent.destination = randomPosition;

        anim.SetFloat("Speed", agent.speed);

        distance = Mathf.Round(Vector3.Distance(randomPosition, transform.position) * 10) / 10;

        if (distance < 0.2f)
        {
            //randomPosition = RandomPoint(transform.position);

            //while (CheckIfOnLayer(randomPosition) == false)
            //{
            //    randomPosition = RandomPoint(transform.position);
            //}

            Destroy(wayPoint);

            randomPosition = CreateRandomPoint(transform.position);

            if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
            {
                Destroy(wayPoint);
                CreatePointCube(randomPosition);
            }
        }

        //if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        //{
        //    Debug.DrawRay(transform.position, Vector3.up * 0.5f, Color.blue, float.MinValue);
        //}

        direction = (randomPosition - transform.position).normalized;
        rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    //Vector3 CreateValidatedPoint(Vector3 pos)
    //{
    //    Vector3 randomPosition = RandomPoint(pos);
    //    while (!CheckIfOnLayer(randomPosition))
    //    {
    //        randomPosition = RandomPoint(pos);
    //    }
    //    return randomPosition;
    //}

    void CreatePointCube(Vector3 pos)
    {
        //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.transform.position = randomPosition;
        //cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //Destroy(cube.GetComponent<Collider>());

        wayPoint = Instantiate(Resources.Load("WayPoint", typeof(GameObject))) as GameObject;
        wayPoint.transform.position = pos;
        Destroy(wayPoint.GetComponent<BoxCollider>());
    }

    Vector3 RandomPoint(Vector3 center)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + pointRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + pointRadius * Mathf.Cos(ang * Mathf.Deg2Rad);


        return pos;
    }

    Vector3 CreateRandomPoint(Vector3 pos)
    {
        //Vector3 randomPoint = pos + new Vector3(Random.insideUnitSphere.x * pointRadius, transform.position.y, Random.insideUnitSphere.z * pointRadius);
        //Vector3 randomPoint = pos + Random.insideUnitSphere * pointRadius;
        Vector3 randomPoint = RandomPoint(pos);
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);
        return hit.position;
    }

    //bool CheckIfOnLayer(Vector3 pos)
    //{
    //    Ray ray = new Ray(pos, Vector3.down);
    //    //Debug.DrawRay(ray.origin, ray.direction, Color.cyan);

    //    return Physics.Raycast(ray);
    //}
}