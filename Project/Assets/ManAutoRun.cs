using UnityEngine;
using System.Collections;

public class ManAutoRun : MonoBehaviour {

    bool moveLeft;
    bool moveRight;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        // when MAN hits GROUND, he starts moving left.
        if (GetComponent<Transform>().position.y <= -3.650688) {
            moveLeft = true;
        }

        // when MAN hits right side of screen, he starts moving left.
        if (GetComponent<Transform>().position.x >= 8.82) {
            moveRight = false;
            moveLeft = true;
        }

        // when MAN hits left side of screen, he starts moving right.
        if (GetComponent<Transform>().position.x <= -8.82) {
            moveLeft = false;
            moveRight = true;
        }

        // MAN move left
        if (moveLeft == true) {
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - 0.1f,
                                                             GetComponent<Transform>().position.y,
                                                             GetComponent<Transform>().position.z);
        }

        // MAN move right
        if (moveRight == true) {
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + 0.1f,
                                                             GetComponent<Transform>().position.y,
                                                             GetComponent<Transform>().position.z);
        }
	
	}
}
