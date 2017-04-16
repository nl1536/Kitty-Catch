using UnityEngine;
using System.Collections;

public class backButton : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Transform>().position = new Vector3(-11f, -4.2f, 0f);
        GetComponent<TargetJoint2D>().target = new Vector2(-11f, -4.2f);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        if (GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite ==
            GameObject.Find("Window").GetComponent<gameState>().info_window_controls) {
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().info_window_story;
        }
        else if (GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite ==
            GameObject.Find("Window").GetComponent<gameState>().info_window_goal) {
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().info_window_controls;
        }
    }
}
