using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

public class UsingSpatialMappingData : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {
        var surfaceObjects = SpatialMappingManager.Instance.GetSurfaceObjects();
        foreach (var surfaceObject in surfaceObjects )
        {
            if(surfaceObject.Object.GetComponent<NavMeshSourceTag>() == null)
            {
                surfaceObject.Object.AddComponent<NavMeshSourceTag>();
            }
        }
    }
}