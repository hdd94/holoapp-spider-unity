using UnityEngine;

/**
* This script counts the start number down and if it reaches 0 it disappears
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class Countdown : MonoBehaviour
    {
        /// <summary>
        /// Startnumber of CountdownGameObject
        /// </summary>
        [Tooltip("Startnumber of CountdownGameObject")]
        public float StartNumber = 5;

        /// <summary>
        /// Linked CountdownGameObject
        /// </summary>
        [Tooltip("Linked CountdownGameObject")]
        public GameObject CountdownGameObject;

        /// <summary>
        /// TextMesh of CountdownGameObject
        /// </summary>
        [Tooltip("Textmesh of CountdownGameObject")]
        public TextMesh CountdownTextMesh;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to assign the global option variable to a script variable and write the variable StartNumber in the textMesh
        /// </summary>
        private void Start()
        {
            CountdownTextMesh.text = StartNumber.ToString();
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to positioning the textmesh in front of the camera and Count the start number down
        /// </summary>    
        private void Update()
        {
            if (!SaveInformations.Instance.IsDeveloperMode && StartNumber > 0)
            {
                StartNumber -= Time.deltaTime;
                CountdownTextMesh.text = ((int)StartNumber).ToString();
            }
            else
                CountdownGameObject.SetActive(false);
        }
    }
}