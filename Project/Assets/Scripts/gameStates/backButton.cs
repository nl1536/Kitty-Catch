﻿using UnityEngine;
using System.Collections;

public class backButton : MonoBehaviour {

    public AudioClip button_click_alt_sfx;

	// Use this for initialization
	void Start () {

        GetComponent<Transform>().position = new Vector3(-11f, -4.2f, 0f);
        GetComponent<TargetJoint2D>().target = new Vector2(-11f, -4.2f);

    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite ==
            GameObject.Find("Window").GetComponent<gameState>().info_window_story) {
            GetComponent<TargetJoint2D>().target = new Vector2(-11f, -4.2f);
        }

        if (GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite ==
            GameObject.Find("Window").GetComponent<gameState>().tutorial_window) {
            GetComponent<TargetJoint2D>().target = new Vector2(-11f, -4.2f);
        }

    }

    void OnMouseDown() {
        GetComponent<Transform>().position = new Vector3(-8.5f, -4.2f, 0f);
        GetComponent<AudioSource>().PlayOneShot(button_click_alt_sfx);

        if (GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite ==
            GameObject.Find("Window").GetComponent<gameState>().info_window_controls) {
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().info_window_story;
            GameObject.Find("ScrollButtonNext").GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.2f);
        }
        else if (GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite ==
            GameObject.Find("Window").GetComponent<gameState>().info_window_goal) {
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().info_window_controls;
            GameObject.Find("ScrollButtonNext").GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.2f);
        }
    }
}
