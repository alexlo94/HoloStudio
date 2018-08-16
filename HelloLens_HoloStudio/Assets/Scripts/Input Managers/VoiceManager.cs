using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace HelloLensPrototype
{
    public class VoiceManager : MonoBehaviour
    {
        //initialize the keyword recognizer object for voice controls and a data structure to hold the keywords
        KeywordRecognizer keywordRecognizer = null;
        //here we choose a dictionary that lets us map strings to system actions (aka methods)
        Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

        void Start() {
            //begin adding the keywords
            //only one for testing purposes
            keywords.Add("Trigger sculpture", () =>{
                GameObject focusObject = gameObject.GetComponent<GazeManager>().FocusedObject;
                if(focusObject != null){
                    focusObject.SendMessage("Selected");
                }
            });

            //now that we have keywords, initialize the recognizer with keywords
            keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

            //register for event handlers
            keywordRecognizer.OnPhraseRecognized += PhraseRecognized;
            keywordRecognizer.Start();

        }

        //event handler for when a keyword is recognized
        private void PhraseRecognized(PhraseRecognizedEventArgs args)
        {
            System.Action keywordAction;
            if(keywords.TryGetValue(args.text, out keywordAction))
            {
                keywordAction.Invoke();
            }

        }
    }
}
