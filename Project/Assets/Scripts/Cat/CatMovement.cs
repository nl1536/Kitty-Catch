using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    public GameObject Cat;

    public bool moveLeft;
    public bool moveRight;
    public bool moveJump;
    public bool moveJumping;

    public bool moveJumpingRight;
    public bool moveJumpingLeft;

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
        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            if (catDed == false) {
                gameObject.layer = 11; // "notDedCats"

                if (moveJumpingRight == true) {
                    moveJumpingLeft = false;
                }
                else {
                    moveJumpingLeft = true;
                }

                // when CAT hits BUILDING, can move left & right & jump & bounces minimally
                if (moveJumping == false) {
                    moveJump = true;
                    GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = true;
                }
                else { // when CAT is jumping, can't move left & right & jump & bounces a lot
                    GetComponent<Animator>().SetBool("Jumping", true);
                    moveLeft = false;
                    moveRight = false;
                    moveJump = false;
                    GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = false;
                    Physics2D.IgnoreLayerCollision(11, 14); // "sideBuilding"

                    // when LEFT ARROW pressed, CAT moves left
                    if (moveJumpingLeft == true && Input.GetKey(KeyCode.LeftArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - .01f,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                    }
                    if (moveJumpingLeft == true && Input.GetKey(KeyCode.RightArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + .08f,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                    }
                    // when RIGHT ARROW pressed, CAT moves right
                    if (moveJumpingRight == true && Input.GetKey(KeyCode.RightArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + .01f,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                    }
                    if (moveJumpingRight == true && Input.GetKey(KeyCode.LeftArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - .08f,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                    }
                }
                // when SPACEBAR pressed, CAT jumps
                if (moveJump == true) {
                    if (Input.GetKeyDown(KeyCode.Space)) {
                        GetComponent<Animator>().SetTrigger("Jump");
                        moveJumping = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
                        GetComponent<AudioSource>().PlayOneShot(cat_meow_sfx);
                    }
                    if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow)) { // if RIGHT ARROW was pressed, jump will go slightly right
                        GetComponent<Animator>().SetTrigger("Jump");
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(150f, 0f), ForceMode2D.Force);
                        moveJumpingRight = true;
                        bounceRight = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow)) { // if LEFT ARROW was pressed, jump will go slightly left
                        GetComponent<Animator>().SetTrigger("Jump");
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-150f, 0f), ForceMode2D.Force);
                        moveJumpingLeft = true;
                        bounceLeft = true;
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
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                    GetComponent<Animator>().SetBool("WalkLeft", false);
                    if (Input.GetKey(KeyCode.RightArrow)) {
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
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                    GetComponent<Animator>().SetBool("WalkRight", false);
                    if (Input.GetKey(KeyCode.LeftArrow)) {
                        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                        moveRight = true;
                    }
                }
            }
        }

            if (catDed == true) {
                moveLeft = false;
                moveRight = false;
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

    void FallTrue() {
        GetComponent<Animator>().SetBool("Fall", true);
    }
}
