using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class RotateBehavior : MonoBehaviour
    {

        public bool selected = false;
        //bool to keep track of the designated behavior state
        public bool RotateBool;

        public void Start()
        {
            RotateBool = transform.parent.gameObject.GetComponent<ArtPieceState>().isRotating;
        }

        public void Update()
        {
            //keep track of this objects bool in accordance with other control behavior
            if (RotateBool == false)
            {
                //selected = false;
                //StopCoroutine("SelectedRotate");
                //transform.rotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.z);
            }
        }

        public void Selected()
        {
            Debug.Log("Control Selected!");
            selected = !selected;
            if (selected == true)
            {
                transform.parent.gameObject.GetComponent<ArtPieceState>().isTranslating = false;
                transform.parent.gameObject.GetComponent<ArtPieceState>().isRotating = true;
                transform.parent.gameObject.GetComponent<ArtPieceState>().isScaling = false;

                StartCoroutine("SelectedRotate");
            }
            else
            {
                transform.parent.gameObject.GetComponent<ArtPieceState>().isRotating = false;

                StopCoroutine("SelectedRotate");
                transform.rotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.z);
            }
        }

        IEnumerator SelectedRotate()
        {
            while (true)
            {
                this.gameObject.transform.Rotate(new Vector3(0.0f, 1f, 0.0f));
                yield return null;
            }
        }
    }
}
