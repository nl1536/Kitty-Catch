using UnityEngine;
using System.Collections;

public class ManAutoRun : MonoBehaviour {

    public GameObject Cat;

    public bool moveLeftRight;
    bool moveLeft;
    bool moveRight;

    float moveSpeed;

	// Use this for initialization
	void Start () {

        moveLeftRight = false;
        moveSpeed = 0.05f;

        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<Renderer>().enabled = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

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

            if (moveLeftRight == true) {
                // when MAN hits right side of screen, he starts moving left.
                if (GetComponent<Transform>().position.x >= 8.85f) {
                    moveRight = false;
                    moveLeft = true;
                }
                // when MAN hits left side of screen, he starts moving right.
                if (GetComponent<Transform>().position.x <= -8.85f) {
                    moveLeft = false;
                    moveRight = true;
                }

                // MAN move left
                if (moveLeft == true) {
                    GetComponent<SpriteRenderer>().flipX = false;
                    GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - moveSpeed,
                                                                     GetComponent<Transform>().position.y,
                                                                     GetComponent<Transform>().position.z);
                }
                // MAN move right
                if (moveRight == true) {
                    GetComponent<SpriteRenderer>().flipX = true;
                    GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + moveSpeed,
                                                                     GetComponent<Transform>().position.y,
                                                                     GetComponent<Transform>().position.z);
                }
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            moveLeftRight = false;
        }
    }

    void OnCollisionEnter2D(Collision2D run) {
        // when MAN hits GROUND, he starts moving left.
        if (run.gameObject.tag == "Ground") { 
            moveLeftRight = true;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    void catchFreeze() {
        moveLeftRight = false;
    }

    void catchUnfreeze() {
        moveLeftRight = true;
    }
}
