using UnityEngine;
using UnityEngine.SceneManagement;

/**
* This script enables the user to reset the app via voice with the keyword "reset"
* 
* @author: Huy Duc Do
* 
**/
public class VoiceScript : MonoBehaviour
{
    /// <summary>
    /// Used to reset the app by load the menu scene and destroying the gameobjects informations and spatialmapping
    /// 
    /// </summary>
	public void Reset () {
        Destroy(GameObject.Find("Informations"));
        Destroy(GameObject.Find("SpatialMapping"));
        SceneManager.LoadScene(0);
    }
}
