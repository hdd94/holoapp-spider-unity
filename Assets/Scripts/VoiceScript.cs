using UnityEngine;
using UnityEngine.SceneManagement;

/**
* This script enables the user to reset the app per voice and the keyword "reset"
* 
* @author: Huy Duc Do
* 
**/
public class ResetScript : MonoBehaviour {

    /// <summary>
    /// Used to delete the gameobject "informations" and "SpatialMapping" and load the main menu scene
    /// </summary>
	public void Reset () {
        Destroy(GameObject.Find("Informations"));
        Destroy(GameObject.Find("SpatialMapping"));
        SceneManager.LoadScene(0);
    }
}
