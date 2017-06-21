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
        public Text MainCountText;
        public Text MainMenuCountText;
        public Button CountIncreaseButton;
        public Button CountDecreaseButton;
        public Toggle DeveloperModeToggle;
        public Toggle ManualPositioningToggle;

        /// <summary>
        /// Used to increase the number of spawning objects if number is less than maximum Count
        /// </summary>
        public void OnClickIncreaseMainCount()
        {
            int number = SaveInformations.Instance.Count;

            if (number < SaveInformations.Instance.MaxCount)
                number++;

            MainCountText.text = number.ToString();
            MainMenuCountText.text = "Spinnenanzahl: " + number;
            SaveInformations.Instance.Count = number;
        }

        /// <summary>
        /// Used to decrease the number of spawning objects if number is higher than 1
        /// </summary>
        public void OnClickDecreaseMainCount()
        {
            int number = SaveInformations.Instance.Count;

            if (number > 1)
                number--;

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
