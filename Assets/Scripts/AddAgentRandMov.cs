using UnityEngine;

/**
* This script adds the movement script to the spawning object
* 
* @author: Huy Duc Do
* 
**/
public class AddAgentRandMov : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.AddComponent<MoveToRandPoints>();
        Destroy(this);
    }
}
