using System;
using UnityEngine;
using UnityEngine.UI;

/**
* This script contains functions to change values of the global options variables spiderCountNumber, IsDeveloperMode, IsManualPositioning, IsUnityMode
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class OptionsPanelController : MonoBehaviour
    {
        /// <summary>
        /// TextObject of main count number
        /// </summary>
        [Tooltip("TextObject of main count number")]
        public Text MainCountText;

        /// <summary>
        /// TextObject of main menu count number
        /// </summary>
        [Tooltip("TextObject of main menu count number")]
        public Text MainMenuCountText;

        /// <summary>
        /// ButtonObject of increase count number button
        /// </summary>
        [Tooltip("ButtonObject of increase count number button")]
        public Button CountIncreaseButton;

        /// <summary>
        /// ButtonObject of decrease count number button
        /// </summary>
        [Tooltip("ButtonObject of decrease count number button")]
        public Button CountDecreaseButton;

        /// <summary>
        /// ToggleObject of developerMode
        /// </summary>
        [Tooltip("ToggleObject of developerMode")]
        public Toggle DeveloperModeToggle;

        /// <summary>
        /// ToggleObject of manualPositioning
        /// </summary>
        [Tooltip("ToggleObject of manualPositioning")]
        public Toggle ManualPositioningToggle;

        /// <summary>
        /// Called only on start if the script is enabled
        /// Used to write the number of count to MainCountText
        /// </summary>
        private void Start()
        {
            MainCountText.text = SaveInformations.Instance.Count.ToString();
        }

        /// <summary>
        /// Used to increase the number of spawning objects if number is less than maximum Count
        /// </summary>
        public void OnClickIncreaseMainCount()
        {
            Debug.Log("Hallo");

            int number = SaveInformations.Instance.Count;

            if (number < SaveInformations.Instance.MaxCount)
            {
                number++;
                CountDecreaseButton.interactable = true;
            }
            else
                CountIncreaseButton.interactable = false;

            WriteNumberToText(number);
        }

        /// <summary>
        /// Used to decrease the number of spawning objects if number is higher than 1
        /// </summary>
        public void OnClickDecreaseMainCount()
        {
            int number = SaveInformations.Instance.Count;

            if (number > 1)
            {
                number--;
                CountIncreaseButton.interactable = true;
            }
            else
                CountDecreaseButton.interactable = false;

            WriteNumberToText(number);
        }

        /// <summary>
        /// Used to write the number of spider to Textmesh
        /// </summary>
        /// <param name="number">number of spider</param>
        public void WriteNumberToText(int number)
        {
            MainCountText.text = number.ToString();
            MainMenuCountText.text = "Spinnenanzahl: " + number;
            SaveInformations.Instance.Count = number;
        }

        /// <summary>
        /// Used to save the selection of developer mode in the global variable IsDeveloperMode
        /// </summary>
        public void OnValueChangedDeveloperModeToggle()
        {
            SaveInformations.Instance.IsDeveloperMode = DeveloperModeToggle.isOn;
        }

        /// <summary>
        /// Used to save the selection of manual positioning in the global variable IsManualPositioning and disables/enables the increase/decrease spawning buttons
        /// </summary>
        public void OnValueChangedManualPositioningToggle()
        {
            SaveInformations.Instance.IsManualPositioning = ManualPositioningToggle.isOn;

            if (ManualPositioningToggle.isOn)
            {
                CountIncreaseButton.interactable = false;
                CountDecreaseButton.interactable = false;
            }
            else
            {
                CountIncreaseButton.interactable = true;
                CountDecreaseButton.interactable = true;
            }
        }
    }
}
