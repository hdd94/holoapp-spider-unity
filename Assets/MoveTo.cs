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

    Quaternion rotation;

    

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
            agent.speed = 1;
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

        if (Vector3.Distance(viewPoint, transform.position) < 1)
        {
            agent.speed = 0;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().mass = 10;
            GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 4, 0), ForceMode.Impulse);
        }
        else 
        {
            agent.speed = 1;
            //GetComponent<NavMeshAgent>().enabled = true;
        }
        Debug.Log(Vector3.Distance(viewPoint, transform.position));

        direction = (Camera.main.transform.position - transform.position).normalized;
        rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}