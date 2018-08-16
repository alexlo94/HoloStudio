using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HelloLensPrototype
{
    public class BeginTourBehavior : MonoBehaviour
    {

        // Use this for initialization
        public GameObject Arty;

        // Use this for initialization
        void Start()
        {
            Arty = GameObject.Find("Arty_FBX");
        }

        public void Selected()
        {
            Arty.GetComponent<ArtyStudioRoom>().enabled = false;
            Arty.GetComponent<ArtyOnTour>().enabled = true;
            Arty.GetComponent<NavMeshAgent>().enabled = true;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
