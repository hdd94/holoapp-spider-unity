// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;
    NavMeshAgent agent;

    Vector3 viewPoint;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = goal.position;

        viewPoint = Camera.main.transform.position + Camera.main.transform.forward * 1;
        agent.destination = viewPoint;
    }
}