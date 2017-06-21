using UnityEngine;
using UnityEngine.SceneManagement;

/**
* This script enables the user to reset the app per voice and the keyword "reset"
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class VoiceScript: MonoBehaviour
    {
        /// <summary>
        /// Used to delete the gameobject "informations" and "SpatialMapping" and load the main menu scene
        /// </summary>
        public void Reset()
        {
            var dontDestroyGameObjects = SaveInformations.Instance.gameObject.scene.GetRootGameObjects();
            foreach (GameObject dontDestroyGameObject in dontDestroyGameObjects)
                Destroy(dontDestroyGameObject);
            SceneManager.LoadScene(0);
        }
    }
}
