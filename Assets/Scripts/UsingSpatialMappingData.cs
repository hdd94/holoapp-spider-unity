using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

/**
* This script adds to each surfaceObject a NavMeshSourceTag for dynamic baking and allows for NavMesh Objects to move on the surfaceObject 
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class UsingSpatialMappingData : MonoBehaviour
    {

        /// <summary>
        /// Called on start independently if the script is enabled/disabled
        /// Don't destroy this script after loading a new scene
        /// </summary>
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to query each surfaceObject if they have an NavMeshSourceTag if not then add to each surfaceObject 
        /// of the SpatialMappingManager a NavMeshSourceTag for dynamic baking and allows for NavMesh Objects to move on the surfaceObject 
        /// </summary>
        private void Update()
        {
            var surfaceObjects = SpatialMappingManager.Instance.GetSurfaceObjects();
            foreach (var surfaceObject in surfaceObjects)
            {
                if (surfaceObject.Object.GetComponent<NavMeshSourceTag>() == null)
                    surfaceObject.Object.AddComponent<NavMeshSourceTag>();
            }
        }
    }
}