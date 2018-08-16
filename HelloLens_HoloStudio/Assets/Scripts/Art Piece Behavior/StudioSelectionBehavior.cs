using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class StudioSelectionBehavior : MonoBehaviour
    {
        public GameObject StudioObjects;
        public GameObject Arty;

        // Use this for initialization
        void Start()
        {
            Arty = GameObject.Find("Arty_FBX");
        }

        public void Selected()
        {
            StudioObjects.SetActive(true);
            Arty.GetComponent<ArtyStudioSelection>().enabled = false;
            Arty.GetComponent<ArtyStudioRoom>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}