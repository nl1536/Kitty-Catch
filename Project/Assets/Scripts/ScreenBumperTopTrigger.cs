using UnityEngine;
using System.Collections;

public class ScreenBumperTopTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // for START screen
        if (GameObject.Find("screenStart").GetComponent<startGame>().start == true) {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (GameObject.Find("screenStart").GetComponent<startGame>().start == false) {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
