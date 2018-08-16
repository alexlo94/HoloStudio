using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class SkipTourBehavior : MonoBehaviour
    {
        public GameObject Arty;

        // Use this for initialization
        void Start()
        {
            Arty = GameObject.Find("Arty_FBX");
        }

        public void Selected()
        {
            Arty.GetComponent<ArtyStudioRoom>().enabled = false;
            Arty.GetComponent<ArtyOffTour>().enabled = true;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
