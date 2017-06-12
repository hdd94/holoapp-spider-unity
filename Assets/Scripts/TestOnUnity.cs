using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

/**
* This script enables the user to play and test the app in the game engine unity
* 
* @author: Huy Duc Do
* 
**/
public class TestOnUnity : MonoBehaviour
{
    /// <summary>
    /// Called only on start if the script is enabled
    /// Adds a mass and gravity to the camera  to be able to move on the spatial mesh room and show the spatial mesh with an predefined 
    /// spatial map
    /// </summary>
    void Start () {
        GameObject camera = GameObject.Find("HoloLensCamera");
        camera.AddComponent<Rigidbody>();
        camera.GetComponent<Rigidbody>().mass = 1e+09f;
        camera.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        GameObject spatialMapping = GameObject.Find("SpatialMapping");
        spatialMapping.GetComponent<SpatialMappingManager>().DrawVisualMeshes = true;
        spatialMapping.GetComponent<ObjectSurfaceObserver>().enabled = true;
    }
}
