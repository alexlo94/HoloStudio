using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInputTest : MonoBehaviour {
    public bool selected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            //Selected();
        }
		
	}

    public void GazeEntered(){
        StartCoroutine("GazeRotate");
    }

    public void GazeExited(){
        StopCoroutine("GazeRotate");
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0.0f, transform.rotation.z);
    }

    public void Selected(){
        selected = !selected;
        if(selected == true){
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else{
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
        }


    }

    IEnumerator GazeRotate(){
        while (true){
            this.gameObject.transform.Rotate(new Vector3(0.0f, 1f, 0.0f));
            yield return null;
        }
    }
}
