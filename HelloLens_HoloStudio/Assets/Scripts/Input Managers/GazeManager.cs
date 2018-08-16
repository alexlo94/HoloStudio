using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype { 
    public class GazeManager : MonoBehaviour {
        //maximum distance for gaze
        public float MaxGazeDistance = 5.0f;
        //designate the layers that raycasting should hit
        public LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;
        //boolean to see if raycast hit something
        public bool Hit;
        //raycast hit information
        public RaycastHit HitInfo;
        //position of the user's gaze
        public Vector3 GazePosition;
        //normal direction of RaycastHit
        public Vector3 Normal;
        private Vector3 gazeOrigin;
        private Vector3 gazeDirection;

        //define placeholder vars for the focused object
        public GameObject FocusedObject;
        private GameObject oldFocusedObject;

        void Start () {
            FocusedObject = null;
        }
	
	    void Update () {
            //update the users head position
            gazeOrigin = Camera.main.transform.position;
            //update the users gaze direction
            gazeDirection = Camera.main.transform.forward;
            //</PROBLEM> this might cause executional problems, pay attention to this line when debugging
            //If there are gaze probleems</PROBLEM>
            oldFocusedObject = FocusedObject;

            UpdateRaycast();

            //check to see if the raycast hit anything
            if (Hit && HitInfo.collider != null){
                //if yes and the object has a collider (it should), set the new focused object
                FocusedObject = HitInfo.collider.gameObject;
            }
            else{
                FocusedObject = null;
            }
            
            /* So far this script has dealt with keeping track of WHERE the user is gazing using raycast info
             * and keeping track of WHAT the user is gazing at by storing the gameobject in FocusedObject.
             * Now it's time to actually use gaze as an input and send GazeEntered and OnGazeExited messages.
             */
             if(FocusedObject != oldFocusedObject){
                //immediately send the gazeExited message to the old focused object
                ResetFocusedInteractible();
                
                //check to see that our user didnt just look away LOL
                if(FocusedObject != null){
                    //if not, check that the new thing we're looking at is interactible
                    if(FocusedObject.tag == "Interactible"){
                        //if all is well up until now, we can safely send a GazeEntered message
                        FocusedObject.SendMessageUpwards("GazeEntered");
                        Debug.Log("GazeEntered!");
                    }
                }
            }

            if (Input.anyKeyDown)
            {
                FocusedObject.SendMessage("Selected");
            }
        }

        //method to calculate the raycast hit position and normal
        private void UpdateRaycast() {
            //make a temporary var to store current hitinfo
            RaycastHit hitInfo;
            //perform the raycast
            Hit = Physics.Raycast(gazeOrigin, gazeDirection, out hitInfo, MaxGazeDistance, RaycastLayerMask);
            //update the Hitinfo property
            HitInfo = hitInfo;

            //check to see if the raycast hit a hologram
            if (Hit) {
                GazePosition = hitInfo.point;
                Normal = hitInfo.normal;
            }
            else {
                GazePosition = gazeOrigin + (gazeDirection * MaxGazeDistance);
                Normal = gazeDirection;
            }
        }

        //method to send Gaze input command OnGazeExited, if the user ever looks away from a hologram
        private void ResetFocusedInteractible() {
            //check to see that our user was actually looking at a hologram before the reset
            if(oldFocusedObject != null){
                //if yes check to see if it was interactible
                if(oldFocusedObject.tag == "Interactible"){
                    //if all is well until now, send a gazeExit message
                    oldFocusedObject.SendMessageUpwards("GazeExited");
                    Debug.Log("GazeExited");
                }
            }
        }
    }
}
