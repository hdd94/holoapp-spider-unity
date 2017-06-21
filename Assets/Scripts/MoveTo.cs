using UnityEngine;
using UnityEngine.AI;

/**
* This script enables an object to move directly
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class MoveTo : MonoBehaviour
    {
        private Animator animator;
        private NavMeshAgent navMeshAgent;

        private Vector3 movePosition;
        private Vector3 lookDirection;
        private Quaternion lookRotation;

        private float stopDistance;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to assign animator controller and a navmesh navMeshAgent to a variable
        /// Adds a navmesh navMeshAgent script if the object has not one and assign a speed value
        /// Freezes the object position to avoid that the object stucks and trembles
        /// </summary>
        private void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (navMeshAgent == null)
            {
                navMeshAgent = this.gameObject.AddComponent<NavMeshAgent>();
                navMeshAgent.speed = 0.2f;
            }

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to update the Vector3 movePosition position as if it moves and set the destination to let the object move to the movePosition
        /// Updates the speed value of the animation controller and stops the object if the object and destination reach an given distance
        /// Changes the object rotation to the destination direction
        /// </summary>
        private void Update()
        {
            movePosition = Camera.main.transform.position;
            movePosition.y = transform.position.y;
            navMeshAgent.SetDestination(movePosition);

            GetComponent<Animator>().SetFloat("Speed", navMeshAgent.speed);

            stopDistance = Mathf.Round(Vector3.Distance(movePosition, transform.position) * 10) / 10;

            if (stopDistance < 0.3f)
                navMeshAgent.speed = 0;
            else
                navMeshAgent.speed = 0.2f;

            lookDirection = (movePosition - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = lookRotation;
        }
    }
}