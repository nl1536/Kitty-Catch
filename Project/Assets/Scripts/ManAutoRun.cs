using UnityEngine;
using System.Collections;

public class ManAutoRun : MonoBehaviour {

    public GameObject Cat;

    bool moveLeftRight;
    bool moveLeft;
    bool moveRight;

    float moveSpeed;

	// Use this for initialization
	void Start () {

        moveLeftRight = false;
        moveSpeed = 0.05f;
    }
	
	// Update is called once per frame
	void Update () {

        // the more CATS the MAN gets, the faster the MAN runs
        if (GetComponent<ManCatchCat>().catsCaught == 0) {
            moveSpeed = 0.05f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 1) {
            moveSpeed = 0.07f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 2) {
            moveSpeed = 0.09f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 3) {
            moveSpeed = 0.11f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 4) {
            moveSpeed = 0.13f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 5) {
            moveSpeed = 0.15f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 6) {
            moveSpeed = 0.17f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 7) {
            moveSpeed = 0.19f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 8) {
            moveSpeed = 0.21f;
        }
        if (GetComponent<ManCatchCat>().catsCaught == 9) {
            moveSpeed = 0.23f;
        }

        // when MAN hits GROUND, he starts moving left.
        if (GetComponent<Transform>().position.y <= -3.650688) {
            moveLeftRight = true;
        }
        
        if (moveLeftRight == true) {
            // when MAN hits right side of screen, he starts moving left.
            if (GetComponent<Transform>().position.x >= 8.81) {
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
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - moveSpeed,
                                                                 GetComponent<Transform>().position.y,
                                                                 GetComponent<Transform>().position.z);
            }
            // MAN move right
            if (moveRight == true) {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + moveSpeed,
                                                                 GetComponent<Transform>().position.y,
                                                                 GetComponent<Transform>().position.z);
            }
        }
	}
}
