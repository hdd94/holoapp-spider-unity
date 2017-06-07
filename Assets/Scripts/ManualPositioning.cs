// //Copyright (c) Microsoft Corporation. All rights reserved.
// //Licensed under the MIT License. See LICENSE in the project root for license information.

//using System;
//using UnityEngine;
//using UnityEngine.VR.WSA.Input;
//using HoloToolkit.Unity.InputModule;

//namespace HoloToolkit.Unity.InputModule
//{
//    /// <summary>
//    /// Simple test script for dropping cubes with physics to observe interactions
//    /// </summary>
//    public class ManualPositioning : MonoBehaviour, IInputClickHandler
//    {
//        //GestureRecognizer recognizer;
//        public GameObject spiderPrefab;

//        private void Start()
//        {
//            //recognizer = new GestureRecognizer();
//            //recognizer.SetRecognizableGestures(GestureSettings.Tap);
//            //recognizer.TappedEvent += Recognizer_TappedEvent;
//            //recognizer.StartCapturingGestures();
//        }

//        //private void OnDestroy()
//        //{
//        //    recognizer.TappedEvent -= Recognizer_TappedEvent;
//        //}

//        //private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
//        //{
//        //    //var cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create a cube
//        //    var spider = GameObject.Instantiate(spiderPrefab); // Create a cube
//        //    spider.transform.localScale = Vector3.one * 0.3f; // Make the cube smaller
//        //    spider.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2; // Start to drop it in front of the camera
//        //    spider.AddComponent<Rigidbody>(); // Apply physics
//        //}

//        public void OnInputClicked(InputClickedEventData eventData)
//        {
//            print("Hello");
//            //var cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create a cube
//            var spider = GameObject.Instantiate(spiderPrefab); // Create a cube
//            spider.transform.localScale = Vector3.one * 0.3f; // Make the cube smaller
//            spider.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2; // Start to drop it in front of the camera
//            spider.AddComponent<Rigidbody>(); // Apply physics
//        }
//    }
//}

using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// manager all measure tools here
/// </summary>
public class ManualPositioning : MonoBehaviour, IInputClickHandler
{

    public GameObject spiderPrefab;

    int timer = 0;

    float generalTimer = 0;

    TextMesh spiderCount;
    TextMesh generalCount;

    GameObject position;

    private void Start()
    {
        InputManager.Instance.PushFallbackInputHandler(gameObject);


        if (GameObject.Find("Informations").GetComponent<SaveInformations>().developerMode)
        {
            spiderCount = GameObject.Find("SpiderCount").GetComponent<TextMesh>();
            generalCount = GameObject.Find("GeneralCount").GetComponent<TextMesh>();
        }
    }

    // place spatial point
    public void OnSelect()
    {
        //manager.AddPoint(LinePrefab, PointPrefab, TextPrefab);

        var spider = GameObject.Instantiate(spiderPrefab); // Create a cube
        spider.transform.localScale = Vector3.one * 0.05f; // Make the cube smaller
        //spider.transform.position = Camera.main.transform.position + Camera.main.transform.forward; // Start to drop it in front of the camera

        Vector3 point = Camera.main.transform.position + Camera.main.transform.forward;

        NavMeshHit hit;
        NavMesh.SamplePosition(point, out hit, 1.0f, NavMesh.AllAreas);

        spider.transform.position = hit.position;

        bool randomMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().randomMovementToggle;
        bool directMovementToggle = GameObject.Find("Informations").GetComponent<SaveInformations>().directMovementToggle;

        if (randomMovementToggle)
        {
            spider.AddComponent<AddAgentRandMov>();
        }
        else if (directMovementToggle)
        {
            spider.AddComponent<AddAgent>();
        }

        timer++;

        spiderCount.text = "Spinnenanzahl: " + timer;

        if (timer == 9)
        {
            spiderCount.text = "Spinnenanzahl: max. " + timer;
            CancelInvoke();
        }

        //GameObject.Find("HoloLensCamera").GetComponent<SpiderInstantiate>().;
    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(timer < 9)
        {
            OnSelect();
        }
    }

    private void Update()
    {
        generalTimer += Time.deltaTime;
        generalCount.text = "Zeit: " + (int)generalTimer;
    }
}

