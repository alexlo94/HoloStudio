using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

namespace HelloLensPrototype
{
    //this script is called when Arty finishes his tour or the user skips the tour
    //this gives Arty his voice command recognizing abilities
    //add 4 keywords to which Arty will respond with a distinct voice line
    //Tell me more about [painting, sculpture, I.I., video];
    public class ArtyOffTour : MonoBehaviour
    {
        //initialize the keyword recognizer object for voice controls and a data structure to hold the keywords
        KeywordRecognizer keywordRecognizer = null;
        //here we choose a dictionary that lets us map strings to system actions (aka methods)
        Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

        public AudioClip PaintingLine;
        public AudioClip VideoLine;
        public AudioClip SculptureLine;
        public AudioClip InstallationLine;

        public AudioSource ArtyMouth;

        // Use this for initialization
        void Start()
        {
            ArtyMouth = this.gameObject.GetComponent<AudioSource>();


            keywords.Add("Tell me more about the painting", () => {
                if (ArtyMouth.isPlaying)
                {
                    ArtyMouth.Stop();
                }
                ArtyMouth.clip = PaintingLine;
                ArtyMouth.Play();
            });
            keywords.Add("Tell me more about the sculpture", () => {
                if (ArtyMouth.isPlaying)
                {
                    ArtyMouth.Stop();
                }
                ArtyMouth.clip = SculptureLine;
                ArtyMouth.Play();
            });
            keywords.Add("Tell me more about the video", () => {
                if (ArtyMouth.isPlaying)
                {
                    ArtyMouth.Stop();
                }
                ArtyMouth.clip = VideoLine;
                ArtyMouth.Play();
            });
            keywords.Add("Tell me more about the installation", () => {
                if (ArtyMouth.isPlaying)
                {
                    ArtyMouth.Stop();
                }
                ArtyMouth.clip = InstallationLine;
                ArtyMouth.Play();
            });

            keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
            //register for event handlers
            keywordRecognizer.OnPhraseRecognized += PhraseRecognized;
            keywordRecognizer.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }

        //event handler for when a keyword is recognized
        private void PhraseRecognized(PhraseRecognizedEventArgs args)
        {
            System.Action keywordAction;
            if (keywords.TryGetValue(args.text, out keywordAction))
            {
                keywordAction.Invoke();
            }

        }
    }
}
