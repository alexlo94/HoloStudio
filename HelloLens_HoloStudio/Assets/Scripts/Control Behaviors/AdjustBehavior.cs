using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class AdjustBehavior : MonoBehaviour
    {
        public bool selected = false;

        // Array for the designer to insert UI elements
        // ALWAYS put "adjust" object in Element 0 of first tier
        public GameObject[] firstTier;
        // ALWAYS put "done" object in Element 0 of second tier
        public GameObject[] secondTier;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Selected()
        {
            selected = !selected;
            if (selected == true)
            { 
                // activate second tier
                for (int i = 0; i < secondTier.Length; i++)
                {
                    secondTier[i].gameObject.SetActive(true);
                }
                // deactivate first tier
                for (int i = 1; i < firstTier.Length; i++)
                {
                    firstTier[i].gameObject.SetActive(false);
                }
                // deactivate self
                firstTier[0].gameObject.SetActive(false);
            }
        }
    }
}