using UnityEngine;
using UnityEngine.AI;

public class MoveToRandPoints : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    Vector3 randomPosition;
    Vector3 lookDirection;
    Quaternion lookRotation;

    float randomPointRadius = 1;
    float destinationDistance;

    bool developerMode;

    GameObject wayPoint;

    void Start()
    {
        anim = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
            agent.speed = 0.2f;
        }

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

        randomPosition = ValidateRandomPoint(transform.position);

        developerMode = GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode;

        if (developerMode)
        {
            CreatePointCube(randomPosition);
        }
    }

    private void Update()
    {
        agent.destination = randomPosition;

        anim.SetFloat("Speed", agent.speed);

        destinationDistance = Mathf.Round(Vector3.Distance(randomPosition, transform.position) * 10) / 10;

        if (destinationDistance < 0.2f)
        {
            if (developerMode)
            {
                Destroy(wayPoint);
            }

            randomPosition = ValidateRandomPoint(transform.position);

            if (developerMode)
            {
                CreatePointCube(randomPosition);
            }
        }

        lookDirection = (randomPosition - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = lookRotation;
    }

    void CreatePointCube(Vector3 pos)
    {
        wayPoint = Instantiate(Resources.Load("WayPoint", typeof(GameObject))) as GameObject;
        wayPoint.transform.position = pos;
        Destroy(wayPoint.GetComponent<BoxCollider>());
    }

    Vector3 RandomPoint(Vector3 center)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + randomPointRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + randomPointRadius * Mathf.Cos(ang * Mathf.Deg2Rad);

        return pos;
    }

    Vector3 ValidateRandomPoint(Vector3 pos)
    {
        Vector3 randomPoint = RandomPoint(pos);
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas);
        return hit.position;
    }
}