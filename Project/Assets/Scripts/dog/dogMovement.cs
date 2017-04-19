using UnityEngine;
using System.Collections;

public class dogMovement : MonoBehaviour {

    public bool moveLeftRight;
    bool moveLeft;
    bool moveRight;

    float jumpForce;
    public float runDistance;

    public AudioClip dog_bark_sfx;
    public AudioClip dog_growl_sfx;

	// Use this for initialization
	void Start () {

        GetComponent<Animator>().SetBool("hasKilled", false);
        moveLeftRight = true;
        runDistance = 5f;
        GetComponent<AudioSource>().mute = false;

	}

    // Update is called once per frame
    void Update() {

        Physics2D.IgnoreLayerCollision(8, 10); // "dedCats"
        Physics2D.IgnoreLayerCollision(8, 12); // "RunningMan"
        Physics2D.IgnoreLayerCollision(8, 17); // "centerBuilding"
        Physics2D.IgnoreLayerCollision(8, 18); // "helicopter"
        Physics2D.IgnoreLayerCollision(8, 19); // "Frame"

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            if (moveLeftRight == true &&
                GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught >= 6) { // when MAN catches 6 CATS, DOG is activated
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

                if (GetComponent<Transform>().position.y <= -5.9) {
                    GetComponent<Animator>().SetBool("Jump", false);
                }

                // if DOG is certain distance to left of CAT, will move RIGHT
                if (GetComponent<Transform>().position.x <= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.x - runDistance) {
                    moveLeft = false;
                    moveRight = true;
                    if (GetComponent<Transform>().position.x >= 0) {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
                    }
                }
                // if DOG is certain distance to right of CAT, will more LEFT
                if (GetComponent<Transform>().position.x >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.x + runDistance) {
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
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                // DOG moves left
                if (moveLeft == true) {
                    gameObject.GetComponent<Renderer>().enabled = true;
                    GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - .1f,
                                                                     GetComponent<Transform>().position.y,
                                                                     GetComponent<Transform>().position.z);
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                // the more CATS caught, the higher the DOG jumps
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 6 &&
                    GetComponent<Transform>().position.y + 3f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    GetComponent<Animator>().SetBool("Jump", true);
                    jumpForce = .3f;
                    runDistance = 5f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 7 &&
                    GetComponent<Transform>().position.y + 3.5f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    GetComponent<Animator>().SetBool("Jump", true);
                    jumpForce = .35f;
                    runDistance = 4f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 8 &&
                    GetComponent<Transform>().position.y + 4f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    GetComponent<Animator>().SetBool("Jump", true);
                    jumpForce = .4f;
                    runDistance = 3f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
                if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 9 &&
                    GetComponent<Transform>().position.y + 4.5f >= GameObject.FindWithTag("totsNotDedCat").GetComponent<Transform>().position.y &&
                    GetComponent<Transform>().position.y <= -3f) {
                    GetComponent<Animator>().SetBool("Jump", true);
                    jumpForce = .45f;
                    runDistance = 2f;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                }
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            GetComponent<Renderer>().enabled = false;
            GetComponent<AudioSource>().mute = true;
        }
    }

    void OnTriggerExit2D(Collider2D jump) {
        if (jump.gameObject.name == "Ground") {
            GetComponent<AudioSource>().PlayOneShot(dog_bark_sfx);
        }
    }

    void killFreeze() {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        moveLeftRight = false;
        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x,
                                                           -5.945045f,
                                                           GetComponent<Transform>().position.z);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(dog_growl_sfx);
    }

    void killUnfreeze()  {
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        moveLeftRight = true;
    }
}

