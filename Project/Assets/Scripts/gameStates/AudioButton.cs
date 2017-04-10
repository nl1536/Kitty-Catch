using UnityEngine;
using System.Collections;

public class AudioButton : MonoBehaviour {

    public Sprite audioButtonOn;
    public Sprite audioButtonOff;

    public bool audioOn;
    
    // Use this for initialization
	void Start () {

        GetComponent<SpriteRenderer>().sprite = audioButtonOn;
        audioOn = true;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (audioOn == true) {
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;
        }
        else if (audioOn == false) {
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
        }
    }

    void OnMouseDown() {
        if (audioOn == true) {
            GetComponent<SpriteRenderer>().sprite = audioButtonOff;
            audioOn = false;
        }
        else if (audioOn == false) {
            GetComponent<SpriteRenderer>().sprite = audioButtonOn;
            audioOn = true;
        }
    }
}
