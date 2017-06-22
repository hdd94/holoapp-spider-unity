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
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        private Vector3 _movePosition;
        private Vector3 _lookDirection;
        private Quaternion _lookRotation;
        private float _stopDistance;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to assign a navMeshAgent to a variable
        /// Adds a navmesh navMeshAgent script if the object has not one 
        /// Freezes the object position to avoid that the object stucks and trembles
        /// </summary>
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            if (_navMeshAgent == null)
            {
                _navMeshAgent = this.gameObject.AddComponent<NavMeshAgent>();
            }

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to update the Vector3 movePosition as if it moves and set the destination to let the object move to the movePosition
        /// Updates the speed value of the animation controller and stops the object if the object and destination reach an given distance
        /// Changes the object rotation to the destination direction
        /// </summary>
        private void Update()
        {
            GetComponent<Animator>().SetFloat("Speed", _navMeshAgent.speed);

            _movePosition = Camera.main.transform.position;
            _movePosition.y = transform.position.y;
            _navMeshAgent.SetDestination(_movePosition);

            _stopDistance = Mathf.Round(Vector3.Distance(_movePosition, transform.position) * 10) / 10;
            if (_stopDistance < 0.3f)
                _navMeshAgent.speed = 0;
            else
                _navMeshAgent.speed = Random.Range(0.13f, 0.17f);

            _lookDirection = (_movePosition - transform.position).normalized;
            _lookRotation = Quaternion.LookRotation(_lookDirection);
            transform.rotation = _lookRotation;
        }
    }
}