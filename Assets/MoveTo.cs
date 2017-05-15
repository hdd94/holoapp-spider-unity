// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    NavMeshAgent agent;

    Vector3 viewPoint;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
        }
    }

    private void Update()
    {
        
            //agent.destination = goal.position;
            viewPoint = Camera.main.transform.position + Camera.main.transform.forward * 1;
            //viewPoint = goal.position + goal.forward * 1;
            agent.destination = viewPoint;
            //agent.SetDestination(GameObject.Find("Camera").transform.position);
    }
}