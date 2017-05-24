// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    Animator anim;

    NavMeshAgent agent;

    Vector3 viewPoint;

    Vector3 direction;

    Vector3 oldVelocity;

    Quaternion rotation;

    float distance;

    

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
        }
        agent.radius = 0.8f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Spider")
        {
            agent.speed = 0;
        } 
        
    }

    private void FixedUpdate()
    {
        //agent.destination = goal.position;
        //viewPoint = goal.position + goal.forward * 1;
        //agent.SetDestination(GameObject.Find("Camera").transform.position);
        viewPoint = Camera.main.transform.position;
        agent.destination = viewPoint;

        anim.SetFloat("Speed", agent.speed);

        distance = Mathf.Round(Vector3.Distance(viewPoint, transform.position) * 10) / 10;
        //distance = Vector3.Distance(viewPoint, transform.position);

        if (distance < 1)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            agent.speed = 0;
            agent.acceleration = float.MaxValue;
            agent.velocity = Vector3.zero;
            agent.isStopped = true;


            //agent.enabled = false;
            //GetComponent<Rigidbody>().mass = 10;
            //GetComponent<Rigidbody>().AddForce(transform.up * 0.3f, ForceMode.Impulse);
        }
        else if (distance > 1.2)
        {
            agent.enabled = true;

            agent.speed = 0.2f;
            agent.acceleration = 8;
            agent.isStopped = false;

        }
        Debug.Log(distance);

        direction = (Camera.main.transform.position - transform.position).normalized;
        rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}