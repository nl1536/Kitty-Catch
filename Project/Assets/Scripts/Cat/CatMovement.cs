using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    public GameObject Cat;

    public bool moveLeft;
    public bool moveRight;
    public bool moveJump;
    public bool moveJumping;

    public bool bounceLeft;
    public bool bounceRight;

    public float moveSpeedRight;
    public float moveSpeedLeft;

    public bool catDed;

    public AudioClip cat_meow_sfx;

	// Use this for initialization
	void Start () {
        
        moveJumping = false;
        moveLeft = true;
        moveRight = true;

        moveSpeedRight = 0.15f;
        moveSpeedLeft = 0.15f;

        catDed = false;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        GetComponent<Animator>().SetBool("Fall", false);

        gameObject.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true ||
            GameObject.Find("Window").GetComponent<gameState>().gameTutorial == true ||
            GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            if (catDed == false) {
                gameObject.layer = 11; // "notDedCats"

                // when CAT hits BUILDING, can move left & right & jump & bounces minimally
                if (moveJumping == false) {
                    moveJump = true;
                    GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = true;
                    Physics2D.IgnoreLayerCollision(11, 14, false); // "sideBuildingLeft"
                    Physics2D.IgnoreLayerCollision(11, 15, false); // "sideBuildingRight"
                    moveSpeedRight = 0.15f;
                    moveSpeedLeft = 0.15f;
                }
                if (moveJumping == true) { // when CAT is jumping, can't move left & right & jump & bounces a lot
                    GetComponent<Animator>().SetBool("Jumping", true);
                    moveRight = true;
                    moveLeft = true;
                    moveJump = false;
                    GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = false;
                    Physics2D.IgnoreLayerCollision(11, 14, true); // "sideBuildingLeft"
                    Physics2D.IgnoreLayerCollision(11, 15, true); // "sideBuildingRight"
                    moveSpeedRight = 0.04f;
                    moveSpeedLeft = 0.04f;
                }
                // when SPACEBAR pressed, CAT jumps
                if (moveJump == true) {
                    if (Input.GetKeyDown(KeyCode.Space)) {
                        GetComponent<Animator>().SetTrigger("Jump");
                        moveJumping = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
                        GetComponent<AudioSource>().PlayOneShot(cat_meow_sfx);
                    }
                    if (Input.GetKeyDown(KeyCode.Space)) { // if RIGHT ARROW was pressed, jump will go slightly right
                        if (Input.GetKeyDown(KeyCode.RightArrow)) {
                            GetComponent<Animator>().SetTrigger("Jump");
                            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4f, 0f), ForceMode2D.Impulse);
                            bounceRight = true;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Space)) { // if LEFT ARROW was pressed, jump will go slightly left
                        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                            GetComponent<Animator>().SetTrigger("Jump");
                            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-4f, 0f), ForceMode2D.Impulse);
                            bounceLeft = true;
                        }
                    }
                }
                // CAT movement (left & right)
                if (moveLeft == true) {
                    // when LEFT ARROW pressed, CAT moves left
                    if (Input.GetKey(KeyCode.LeftArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - moveSpeedLeft,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                        GetComponent<SpriteRenderer>().flipX = false;
                        GetComponent<Animator>().SetBool("WalkLeft", true);
                    }
                    else {
                        GetComponent<Animator>().SetBool("WalkLeft", false);
                        }
                }
                if (moveLeft == false) {
                    if (moveJumping == false) {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                    }
                    GetComponent<Animator>().SetBool("WalkLeft", false);
                    if (moveJumping == false && Input.GetKey(KeyCode.RightArrow)) {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        moveLeft = true;
                    }
                }
                if (moveRight == true) {
                    // when RIGHT ARROW pressed, CAT moves right
                    if (Input.GetKey(KeyCode.RightArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + moveSpeedRight,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                        GetComponent<SpriteRenderer>().flipX = true;
                        GetComponent<Animator>().SetBool("WalkRight", true);
                    }
                    else {
                        GetComponent<Animator>().SetBool("WalkRight", false);
                    }
                }
                if (moveRight == false) {
                    if (moveJumping == false) {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                    }
                    GetComponent<Animator>().SetBool("WalkRight", false);
                    if (moveJumping == false && Input.GetKey(KeyCode.LeftArrow)) {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        moveRight = true;
                    }
                }
            }
        }

            if (catDed == true) {
                moveLeft = false;
                moveRight = false;
                moveJumping = false;
                gameObject.layer = 10; // "dedCats"
                gameObject.tag = "dedCat";
            }
        }

    void OnTriggerEnter2D(Collider2D restrictMovement) {
        if (restrictMovement.gameObject.tag == "leftBuilding") {
            moveLeft = false;
            }
        if (restrictMovement.gameObject.tag == "rightBuilding") {
            moveRight = false;
            }
        }

    void OnCollisionEnter2D(Collision2D bounce) {
        if (bounce.gameObject.tag == "Ground" && Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1f, 0f), ForceMode2D.Impulse);
        }
        if (bounce.gameObject.tag == "Ground" && Input.GetKey(KeyCode.RightArrow)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f), ForceMode2D.Impulse);
        }
    }

    void FallTrue() {
        GetComponent<Animator>().SetBool("Fall", true);
    }
}
