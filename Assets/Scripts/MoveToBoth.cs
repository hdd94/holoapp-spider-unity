using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveToBoth : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    Vector3 viewPoint;
    float stopDistance;

    Vector3 randomPosition;
    float pointRadius = 1;
    float reachDistance;
    GameObject wayPoint;

    Vector3 direction;
    Quaternion rotation;
    
    // Use this for initialization
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


    }

    private void Update()
    {
        viewPoint = Camera.main.transform.position;
        viewPoint.y = transform.position.y;
        agent.destination = viewPoint;

        anim.SetFloat("Speed", agent.speed);

        stopDistance = Mathf.Round(Vector3.Distance(viewPoint, transform.position) * 10) / 10;

        if (stopDistance < 1)
        {
            agent.speed = 0;
        }
        else if (stopDistance > 1.05f)
        {
            agent.speed = 0.2f;
        }

        direction = (viewPoint - transform.position).normalized;
        rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}