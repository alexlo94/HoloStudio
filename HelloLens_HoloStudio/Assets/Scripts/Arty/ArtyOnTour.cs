using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace HelloLensPrototype
{
    public class ArtyOnTour : MonoBehaviour
    {
        public Transform[] TourStops;
        public AudioClip[] TourLines;

        public AudioSource ArtyMouth;
        public NavMeshAgent ArtyNav;

        public AudioClip FollowMe;

        // Use this for initialization
        void Start()
        {
            ArtyMouth = this.gameObject.GetComponent<AudioSource>();
            ArtyNav = this.gameObject.GetComponent<NavMeshAgent>();
            StartCoroutine(TourBegin());
        }

        IEnumerator TourBegin()
        {
            ArtyMouth.clip = FollowMe;
            ArtyMouth.Play();
            while (ArtyMouth.isPlaying && ArtyMouth.clip == FollowMe)
            {
                yield return null;
            }

            StartCoroutine(ShowExhibit(0));
        }

        IEnumerator ShowExhibit(int pointer)
        {
            Debug.Log(pointer);
            ArtyNav.destination = TourStops[pointer].position;
            ArtyMouth.clip = TourLines[pointer];
            while (transform.position != ArtyNav.destination)
            {
                yield return null;
            }
            ArtyMouth.Play();
            while (ArtyMouth.isPlaying && ArtyMouth.clip == TourLines[pointer])
            {
                yield return null;
            }

            if (pointer < 3)
            {
                StartCoroutine(ShowExhibit(pointer + 1));
            }
            else
            {
                this.gameObject.GetComponent<ArtyOffTour>().enabled = true;
                this.enabled = false;
            }
        }
    }
}
