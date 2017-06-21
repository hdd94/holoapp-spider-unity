using HoloToolkit.Unity;
using UnityEngine;

/**
* This script saves all option variables and makes them global
* 
* @author: Huy Duc Do
* 
**/
namespace HoloAppSpider
{
    public class SaveInformations : Singleton<SaveInformations>
    {
        public int MaxCount;
        public int Count;
        public bool IsDeveloperMode;
        public bool IsManualPositioning;

        /// <summary>
        /// Called on start independently if the script is enabled/disabled
        /// Don't destroy this script after loading a new scene
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
        }
    }
}
