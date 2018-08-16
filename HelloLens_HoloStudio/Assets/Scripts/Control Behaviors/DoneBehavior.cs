using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class DoneBehavior : MonoBehaviour
    {
        public bool selected = false;

        // Array for Designer to insert UI elements
        // ALWAYS put "adjust" object in Element 0 of first tier
        public GameObject[] firstTier;
        // ALWAYS put "done" object in Element 0 of second tier
        public GameObject[] secondTier;

        public void GazeEntered()
        {
            Debug.Log("Gaze Entered");
        }
        public void GazeExited()
        {
            Debug.Log("Gaze Exited");
        }

        public void Selected()
        {
            selected = !selected;
            Debug.Log("Select method triggered");
                // activate first tier
                for (int i = 0; i < firstTier.Length; i++)
                {
                    firstTier[i].gameObject.SetActive(true);
                }
                // deactivate second tier
                for (int i = 1; i < secondTier.Length; i++)
                {
                    secondTier[i].gameObject.SetActive(false);
                }
                // deacvitave self
                secondTier[0].gameObject.SetActive(false);
        }
    }
}