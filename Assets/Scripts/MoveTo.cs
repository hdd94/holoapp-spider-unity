using UnityEngine;
using UnityEngine.AI;

/**
* This script enables an object to move directly
* 
* @author: Huy Duc Do
* 
**/
public class MoveTo : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;

    Vector3 movePoint;
    Vector3 lookDirection;
    Quaternion lookRotation;

    float stopDistance;

    /// <summary>
    /// Called only on start if the script is enabled
    /// Used to assign animator controller and a navmesh agent to a variable
    /// Adds a navmesh agent script if the object has not one and assign a speed value
    /// Freezes the object position to avoid that the object stucks and trembles
    /// </summary>
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
    }

    /// <summary>
    /// Update is called once per frame
    /// Used to update the Vector3 movePoint position as if it moves and set the destination to let the object move to the movePoint
    /// Updates the speed value of the animation controller and stops the object if the object and destination reach an given distance
    /// Changes the object rotation to the destination direction
    /// </summary>
    private void Update()
    {
        movePoint = Camera.main.transform.position;
        movePoint.y = transform.position.y;
        agent.SetDestination(movePoint);

        anim.SetFloat("Speed", agent.speed);

        stopDistance = Mathf.Round(Vector3.Distance(movePoint, transform.position) * 10) / 10;

        if (stopDistance < 0.3f)
        {
            agent.speed = 0;
        }
        else 
        {
            agent.speed = 0.2f;
        }

        lookDirection = (movePoint - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = lookRotation;
    }
}