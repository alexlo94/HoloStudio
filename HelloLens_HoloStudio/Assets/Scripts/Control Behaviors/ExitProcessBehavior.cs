using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class ExitProcessBehavior : MonoBehaviour
    {
        // GameObject Array for main art pieces in the scene
        // DO NOT ADD SELF ARTPIECE TO ARRAY
        public GameObject[] Art_Pieces;

        // GameObject Array for objects related to the art piece process
        public GameObject[] Process_Objects;

        // The ProcessCube GameObject attached to the Art Piece Parent
        public GameObject Process_Sign;
        public GameObject Adjust_Sign;
        public bool selected = false;

        public void Selected()
        {
            // Function Features:
            // Activate the "exit" button
            // Activate the Objects that make up the process for the attached artpiece
            // Deactivate the other Art Pieces in 'Art_Pieces'
            selected = !selected;

            // Activate the ProcessCube and AdjustCube
            Process_Sign.gameObject.SetActive(true);
            Adjust_Sign.gameObject.SetActive(true);
            // Loops for deactivating and activating the Art Pieces and Process Pieces
            for (int i = 0; i < Art_Pieces.Length; i++)
            {
                Art_Pieces[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < Process_Objects.Length; i++)
            {
                Process_Objects[i].gameObject.SetActive(false);
            }
            // Set this Object as inactive
            // Also exits script
            this.gameObject.SetActive(false);
        }
    }
}
