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
        /// GameObject of countdown
        /// </summary>
        [Tooltip("GameObject of countdown")]
        public GameObject CountdownGameObject;

        /// <summary>
        /// TextMeshObject of countdown
        /// </summary>
        [Tooltip("TextmeshObject of countdown")]
        public TextMesh CountdownTextMesh;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to write the variable StartNumber in the textMesh
        /// </summary>
        private void Start()
        {
            CountdownTextMesh.text = StartNumber.ToString();
        }

        /// <summary>
        /// Update is called once per frame
        /// Used to count the start number down and let it disappear if it reaches 0
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