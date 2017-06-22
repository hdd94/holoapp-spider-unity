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
        /// <summary>
        /// Global number of max count 
        /// </summary>
        [Tooltip("Global number of max count")]
        public int MaxCount;

        /// <summary>
        /// Global number of count
        /// </summary>
        [Tooltip("Global number of count")]
        public int Count;

        /// <summary>
        /// Global bool variable if developerMode should be active
        /// </summary>
        [Tooltip("Global bool variable if developerMode should be active")]
        public bool IsDeveloperMode;

        /// <summary>
        /// Global bool variable if manualPositioning should be active
        /// </summary>
        [Tooltip("Global bool variable if manualPositioning should be active")]
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
