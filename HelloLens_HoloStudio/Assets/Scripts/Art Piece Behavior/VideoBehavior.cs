using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelloLensPrototype
{
    public class VideoBehavior : MonoBehaviour
    {   
        // array for designer to fill in objects that will activate when selected
        public GameObject[] ToolBelt;
        public bool selected = false;

        public void GazeEntered()
        {
            //gameObject.transform.localScale = new Vector3(2.2f, 1.1f, 0.04f);
        }

        public void GazeExited()
        {
            //gameObject.transform.localScale = new Vector3(2f, 1f, 0.04f);
        }

        public void Selected()
        {
            selected = !selected;
            // if object is selected, activate the main toolbelt elements as defined by Designer
            if (selected == true)
            {
                for (int i = 0; i < ToolBelt.Length; i++)
                {
                    ToolBelt[i].SetActive(true);
                }
            }
            else
            // when de-selected, deactivate the toolbelt defined by Designer
            {
                for (int i = 0; i < ToolBelt.Length; i++)
                {
                    ToolBelt[i].SetActive(false);
                }
            }
        }
    }
}
