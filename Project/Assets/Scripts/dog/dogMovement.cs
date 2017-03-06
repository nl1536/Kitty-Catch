using UnityEngine;
using System.Collections;

public class dogMovement : MonoBehaviour {

    bool moveLeft;
    bool moveRight;

    float jumpForce;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {

        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(8, 12);
        Physics2D.IgnoreLayerCollision(8, 17);
        Physics2D.IgnoreLayerCollision(8, 18);

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught >= 6) { // when MAN catches 6 CATS, DOG is activated
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                // if DOG hits left side of screen, will move RIGHT
                if (GetComponent<Transform>().position.x <= -7f) {
                    moveLeft = false;
                    moveRight = true;
                    if (GetComponent<Transform>().position.x >= 0) {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
                    }
                }
                // if DOG hits right side of screen, will more LEFT
                if (GetComponent<Transform>().position.x >= 7f) {
                    moveRight = false;
                    moveLeft = true;
                    if (GetComponent<Transform>().position.x >= 0) {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
                    }
                }
                // DOG moves right
                if (moveRight == true) {
                    gameObject.GetComponent<Renderer>().enabled = true;
                    GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + .1f,
                                                                     GetComponent<Transform>().position.y,
                                                                     GetComponent<Transform>().position.z);
                }
                // DOG moves left
                if (moveLeft == true) {
                    gameObject.GetComponent<Renderer>().enabled = true;
                    GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - .1f,
                                                                     GetComponent<Transform>().position.y,
                                                                     GetComponent<Transform>().position.z);
                }
                // the more CATS caught, the higher the DOG jumps
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 6 &&
                    GetComponent<Transform>().position.y + 2.5f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    jumpForce = .3f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 7 &&
                    GetComponent<Transform>().position.y + 3f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    jumpForce = .35f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 8 &&
                    GetComponent<Transform>().position.y + 3.5f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    jumpForce = .4f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 9 &&
                    GetComponent<Transform>().position.y + 4f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    jumpForce = .45f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            GetComponent<Transform>().position = new Vector3(12.5f, -2.5f, GetComponent<Transform>().position.z);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            GetComponent<Renderer>().enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D killCat) {
        if (killCat.gameObject.tag == "totsNotDedCat") {
            //killCat.gameObject.GetComponent<Renderer>().enabled = false;
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x, -3.5f,
                                                             GetComponent<Transform>().position.z);
        }
    }
}

