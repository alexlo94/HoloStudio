using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    //attach this script to objects that are supposed to 
    public class ArtPieceState : MonoBehaviour
    {
        //series of bools used to store the manipulation state of each art piece
        public bool isRotating = false;
        public bool isScaling = false;
        public bool isTranslating = false;

        //there's a possibility this script might have to be merged with each individual
        //art piece behavior script. I'm keeping it separate for now to see if any problems arise.
        public GestureManager gestureManager;
        public GameObject focusedObject;

        public float rotationSens = 5f;
        public float scaleSens = 0.001f;

        public void Start()
        {
            gestureManager = GameObject.Find("Managers").GetComponent<GestureManager>();
            //focusedObject = GameObject.Find("Managers").GetComponent<GazeManager>().FocusedObject;
        }

        public void Update()
        {
            focusedObject = GameObject.Find("Managers").GetComponent<GazeManager>().FocusedObject;
            PerformNavigation();
        }

        public void PerformNavigation()
        {
            //check to see if we're in rotate mode or scale mode
            if (isRotating)
            {
                //perform rotation
                if (gestureManager.IsNavigating && (focusedObject == this.gameObject) )
                {
                    float rotationFactor = gestureManager.NavigationPosition.x * rotationSens;
                    transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
                }
            }
            else if (isScaling)
            {
                Debug.Log("Scaling is happening");
                //perform scaling
                if (gestureManager.IsNavigating && (focusedObject == this.gameObject))
                {
                    Debug.Log("scaling is REALLY happening");
                    float scaleFactor = gestureManager.NavigationPosition.x * scaleSens;
                    //Vector3.Scale(transform.localScale, new Vector3(scaleFactor, scaleFactor, scaleFactor));
                    //transform.localScale.Scale(new Vector3(scaleFactor, scaleFactor, scaleFactor));
                    transform.localScale = transform.localScale * (Mathf.Abs(scaleFactor) + 0.1f);
                }
            }
            else
            {
                return;
            }
        }
    }
}
