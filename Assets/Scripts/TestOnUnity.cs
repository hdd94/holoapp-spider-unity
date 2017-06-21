using HoloToolkit.Unity.SpatialMapping;
using UnityEngine;

/**
* This script enables the user to play and test the app in the game engine unity
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class TestOnUnity : MonoBehaviour
    {
        /// <summary>
        /// Called only on start if the script is enabled
        /// Adds a mass and gravity to the camera  to be able to move on the spatial mesh room and show the spatial mesh with an predefined 
        /// spatial map
        /// </summary>
        private void Start()
        {
            GameObject camera = Camera.main.gameObject;
            Rigidbody cameraRigidbody = camera.AddComponent<Rigidbody>();
            cameraRigidbody.mass = 1e+09f;
            cameraRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            SpatialMappingManager.Instance.DrawVisualMeshes = true;
            SpatialMappingManager.Instance.gameObject.GetComponent<ObjectSurfaceObserver>().enabled = true;
        }
    }
}