using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMovement : MonoBehaviour {

    float speed = 1f;

    float distance = 1;

    Rigidbody rb;

    Vector3 camDir;

    public Vector3 viewPoint;

    public Vector3 CamDir;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //if (follow)
        //{
        //Zielpunkt - Anfangspunkt ergibt Bewegungsrichtung
        //normalized = Vektor mit einem Einheitswert zurückgeben

        viewPoint = Camera.main.transform.position + Camera.main.transform.forward * distance;
        CamDir = (viewPoint - transform.position).normalized;
  

        rb.AddForceAtPosition(CamDir, transform.position);

        rb.MovePosition(transform.position + CamDir * speed * Time.deltaTime);

        float distanceBetween = Vector3.Distance(viewPoint, transform.position);
        print(distanceBetween);
        if (distanceBetween > 10) {
            Destroy(this.gameObject);
        }
        //}

        //viewPoint = Camera.main.transform.position + Camera.main.transform.forward;
        //viewPoint.y = rb.transform.position.y;
        //print(viewPoint);

        //Vector3 newPosition = Vector3.MoveTowards(rb.transform.position, viewPoint, speed * Time.deltaTime);
        //rb.MovePosition(newPosition);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag == "MainCamera")
    //    { 
    //    follow = false;
    //    print("hello");
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    follow = true;
    //}
}
