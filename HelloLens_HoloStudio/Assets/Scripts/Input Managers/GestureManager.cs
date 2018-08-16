using UnityEngine;


namespace HelloLensPrototype
{
    public class GestureManager : MonoBehaviour
    {
        //initialize gesture recognizers for Tap, Navigation and Manipulation gestures
        public UnityEngine.XR.WSA.Input.GestureRecognizer NavigationRecognizer;
        public UnityEngine.XR.WSA.Input.GestureRecognizer ManipulationRecognizer;
        //set aside a var for the currently active recognizer
        public UnityEngine.XR.WSA.Input.GestureRecognizer ActiveRecognizer;

        //boolean values to keep track of gestures performed
        public bool IsNavigating;
        public bool IsManipulating;

        //V3 values to keep track of gesture positions
        public Vector3 NavigationPosition;
        public Vector3 ManipulationPosition;

        void Awake(){
            //instantiate the gesture recognizers
            NavigationRecognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
            ManipulationRecognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
            //add the appropriate recognizable gestures to each one
            //for more info on these gestures refer to https://developer.microsoft.com/en-us/windows/mixed-reality/gestures
            NavigationRecognizer.SetRecognizableGestures(UnityEngine.XR.WSA.Input.GestureSettings.Tap | UnityEngine.XR.WSA.Input.GestureSettings.NavigationX); //NavigationX will keep track of Air tap & hold in the X direction
            ManipulationRecognizer.SetRecognizableGestures(UnityEngine.XR.WSA.Input.GestureSettings.ManipulationTranslate);

            //register the navigation event handlers with the functions below
            NavigationRecognizer.TappedEvent += NavTapped;
            NavigationRecognizer.NavigationStartedEvent += NavStarted;
            NavigationRecognizer.NavigationUpdatedEvent += NavUpdated;
            NavigationRecognizer.NavigationCompletedEvent += NavCompleted;
            NavigationRecognizer.NavigationCanceledEvent += NavCanceled;

            //register the manipulation event handlers with the functions below
            ManipulationRecognizer.ManipulationStartedEvent += ManStarted;
            ManipulationRecognizer.ManipulationUpdatedEvent += ManUpdated;
            ManipulationRecognizer.ManipulationCompletedEvent += ManCompleted;
            ManipulationRecognizer.ManipulationCanceledEvent += ManCanceled;

            ResetGestureRecognizers();

        }

        //method to reset back to the default GestureRecognizer
        public void ResetGestureRecognizers(){
            Transition(NavigationRecognizer);
        }
        //method to transition to a new GestureRecognizer
        public void Transition(UnityEngine.XR.WSA.Input.GestureRecognizer newRecognizer){
            //check if input parameter is null
            if(newRecognizer == null) {
                return;
            }
            if(ActiveRecognizer != null){
                //if the active recognizer isn't null and not the same as the new recognizer cancel all gesures and complete the switch
                if(ActiveRecognizer == newRecognizer){
                    return;
                }
                ActiveRecognizer.CancelGestures();
                ActiveRecognizer = newRecognizer;
            }
            newRecognizer.StartCapturingGestures();
            ActiveRecognizer = newRecognizer;
        }

        //navigation event handlers
        //method to send an OnSelect message to the focused object when the user airtaps
        private void NavTapped(UnityEngine.XR.WSA.Input.InteractionSourceKind source, int tapCount, Ray ray){
            GameObject focusedObject = this.gameObject.GetComponent<GazeManager>().FocusedObject;
            if(focusedObject != null){
                focusedObject.SendMessage("Selected");
            }
        }
        private void NavStarted(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 relativePosition, Ray ray){
            IsNavigating = true;
            NavigationPosition = relativePosition;
        }
        private void NavUpdated(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 relativePosition, Ray ray){
            IsNavigating = true;
            NavigationPosition = relativePosition;
        }
        private void NavCompleted(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 relativePosition, Ray ray){
            IsNavigating = false;
        }
        private void NavCanceled(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 relativePosition, Ray ray){
            IsNavigating = false;
        }

        //manipulation event handlers
        private void ManStarted(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 position, Ray ray){
            GameObject focusedObject = this.gameObject.GetComponent<GazeManager>().FocusedObject;
            if (focusedObject != null){
                IsManipulating = true;
                ManipulationPosition = position;
                focusedObject.gameObject.SendMessage("ManipulationStart");
            }
        }
        private void ManUpdated(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 position, Ray ray){
            GameObject focusedObject = this.gameObject.GetComponent<GazeManager>().FocusedObject;
            if (focusedObject != null){
                IsManipulating = true;
                ManipulationPosition = position;
                focusedObject.gameObject.SendMessage("ManipulationUpdate");
            }
        }
        private void ManCompleted(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 position, Ray ray){
            IsManipulating = false;

        }
        private void ManCanceled(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Vector3 position, Ray ray){
            IsManipulating = false;

        }

        void OnDestroy()
        {
            NavigationRecognizer.TappedEvent -= NavTapped;

            NavigationRecognizer.NavigationStartedEvent -= NavStarted;
            NavigationRecognizer.NavigationUpdatedEvent -= NavUpdated;
            NavigationRecognizer.NavigationCompletedEvent -= NavCompleted;
            NavigationRecognizer.NavigationCanceledEvent -= NavCanceled;

            // Unregister the Manipulation events on the ManipulationRecognizer.
            ManipulationRecognizer.ManipulationStartedEvent -= ManStarted;
            ManipulationRecognizer.ManipulationUpdatedEvent -= ManUpdated;
            ManipulationRecognizer.ManipulationCompletedEvent -= ManCompleted;
            ManipulationRecognizer.ManipulationCanceledEvent -= ManCanceled;
        }
    }
}
