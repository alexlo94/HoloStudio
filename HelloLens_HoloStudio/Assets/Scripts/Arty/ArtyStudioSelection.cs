using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class ArtyStudioSelection : MonoBehaviour
    {
        //container to store Arty's voice lines for this scene
        public AudioClip[] VoiceLines;
        public AudioSource ArtyMouth;

        public GameObject StudioPanel;


        // Use this for initialization
        void Start()
        {
            ArtyMouth = this.gameObject.GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Selected()
        {
            //display studio selection menu
            StartCoroutine(VoiceInteraction(VoiceLines[0], StudioPanel));
        }

        //coroutine that triggers Arty to play a voiceline and then display a menu
        IEnumerator VoiceInteraction(AudioClip clip, GameObject targetObject)
        {
            ArtyMouth.clip = clip;
            ArtyMouth.Play();
            //wait for Arty to finish his voiceline
            while (ArtyMouth.isPlaying && clip == ArtyMouth.clip)
            {
                yield return null;
            }
            //if we've passed on an object, activate it
            if (targetObject != null)
            {
                Debug.Log("Object was not null");
                targetObject.SetActive(true);
                yield return null;
            }
            else
            {
                Debug.Log("object was null");
                yield return null;
            }
        }
    }
}
