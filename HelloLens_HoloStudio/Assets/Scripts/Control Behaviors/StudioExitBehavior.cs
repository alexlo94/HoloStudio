using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class StudioExitBehavior : MonoBehaviour
    {
        // GameObject Array for main art pieces in the scene
        // DO NOT ADD SELF ARTPIECE TO ARRAY
        public GameObject[] Art_Pieces;
        public GameObject Studio_Select;

        public bool selected = false;

        public void Selected()
        {
            selected = !selected;

            Studio_Select.gameObject.SetActive(true);
            for (int i = 0; i < Art_Pieces.Length; i++)
            {
                Art_Pieces[i].gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }
}