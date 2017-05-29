using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnUnity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject camera = GameObject.Find("HoloLensCamera");
        camera.AddComponent<Rigidbody>();
        camera.GetComponent<Rigidbody>().mass = 1e+09f;
        camera.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        GameObject spatialMapping = GameObject.Find("SpatialMapping");
        spatialMapping.GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;
        spatialMapping.GetComponent<ObjectSurfaceObserver>().enabled = true;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
