using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class ScaleBehavior : MonoBehaviour
    {

        public bool selected = false;
        //bool to keep track of the designated behavior state
        public bool ScaleBool;

        public void Start()
        {
            ScaleBool = transform.parent.gameObject.GetComponent<ArtPieceState>().isScaling;
        }

        public void Update()
        {
            //keep track of this objects bool in accordance with other control behavior
            if (ScaleBool == false)
            {
                //selected = false;
                //StopCoroutine("SelectedRotate");
                //transform.rotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.z);
            }
        }

        public void Selected()
        {
            selected = !selected;
            if (selected == true)
            {
                transform.parent.gameObject.GetComponent<ArtPieceState>().isTranslating = false;
                transform.parent.gameObject.GetComponent<ArtPieceState>().isRotating = false;
                transform.parent.gameObject.GetComponent<ArtPieceState>().isScaling = true;

                StartCoroutine("SelectedRotate");
            }
            else
            {
                transform.parent.gameObject.GetComponent<ArtPieceState>().isScaling = false;

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
