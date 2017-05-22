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

    Vector3 center;

    float pointRadius = 1;

    float distance;

    void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
            agent.speed = 1;
            agent.acceleration = 60;
        }

        center = transform.position;
        randomPosition = RandomCircle(center, pointRadius);
        Debug.Log(randomPosition);
    }

    private void OnCollisionStay(Collision collision)
    {
        center = transform.position;
        randomPosition = RandomCircle(center, pointRadius);
        Debug.Log(randomPosition);
    }

    private void Update()
    {
        agent.destination = randomPosition;

        anim.SetFloat("Speed", agent.speed);

        distance = Mathf.Round(Vector3.Distance(randomPosition, transform.position) * 10) / 10;

        if (distance < 0.5f)
        {
            center = transform.position;
            randomPosition = RandomCircle(center, pointRadius);
            Debug.Log(randomPosition);
        }

        direction = (randomPosition - transform.position).normalized;
        rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}