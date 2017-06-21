using UnityEngine;

/**
* This script adds the movement script to the spawning object
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class AddAgent : MonoBehaviour
    {
        /// <summary>
        /// Used to add the movement script to the spawning object when it enters the collision with the ground
        /// and destroys this script after adding the script
        /// </summary>
        /// <param name="collision">ground collision</param> 
        private void OnCollisionEnter(Collision collision)
        {
            this.gameObject.AddComponent<MoveTo>();
            Destroy(this);
        }
    }
}
