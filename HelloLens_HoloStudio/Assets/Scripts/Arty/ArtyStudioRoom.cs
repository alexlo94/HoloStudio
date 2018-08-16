using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class ArtyStudioRoom : MonoBehaviour
    {
        //container to store Arty's voice lines for this scene
        public AudioClip[] VoiceLines;
        public AudioSource ArtyMouth;
        public GameObject TourMenu;

        // Use this for initialization
        void Start()
        {
            ArtyMouth = this.gameObject.GetComponent<AudioSource>();
            StartCoroutine("StudioStart");

        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator StudioStart()
        {
            ArtyMouth.clip = VoiceLines[0];
            ArtyMouth.Play();

            while(ArtyMouth.isPlaying && ArtyMouth.clip == VoiceLines[0])
            {
                yield return null;
            }
            if(TourMenu != null)
            {
                TourMenu.SetActive(true);
            }
            else
            {
                yield return null;
            }
        }
    }
}
