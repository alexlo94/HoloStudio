using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class CursorManager : MonoBehaviour
    {
        //define colors for when the cursor is on and off holograms
        public Color ColorOnHolograms;
        public Color ColorOffHolograms;

        //instantiate the Gazemanager script from Managers object to have access to the raycast info
        private GazeManager gazeManager;

        // Use this for initialization
        private void Awake()
        {
            //find and make references to the Gazemanager script and the material of the cursor
            gazeManager = GameObject.Find("Managers").GetComponent < GazeManager > ();
        }

        // Update is called once per frame
        void Update()
        {
            //check the bool in the gazemanager, lets us know if a hologram is in our view
            if (gazeManager.Hit){
                //if a hologram is in our view, use the white color
                this.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
            else {
                //if not, use the dim gray color
                this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }

            //set the position of the cursor to where the user is looking
            gameObject.transform.position = gazeManager.GazePosition;
            gameObject.transform.up = gazeManager.Normal;
        }
    }
}
