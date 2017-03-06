using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    public GameObject Cat;

    public bool moveLeftRight;
    public bool moveJump;
    public bool moveJumping;

    public bool bounceLeft;
    public bool bounceRight;

    public float moveSpeedRight;
    public float moveSpeedLeft;

    public bool catDed;

	// Use this for initialization
	void Start () {
        
        moveJumping = false;

        moveSpeedRight = 0.15f;
        moveSpeedLeft = 0.15f;

        catDed = false;

        gameObject.GetComponent<Renderer>().enabled = true;
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

            if (catDed == false) {
                gameObject.layer = 11;
                // when CAT hits BUILDING, can move left & right & jump & bounces minimally
                if (moveJumping == false) {
                    moveLeftRight = true;
                    moveJump = true;
                    GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = true;
                }
                else { // when CAT is jumping, can't move left & right & jump & bounces a lot
                    moveLeftRight = false;
                    moveJump = false;
                    GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = false;
                }
                // when SPACEBAR pressed, CAT jumps
                if (moveJump == true) {
                    if (Input.GetKeyDown(KeyCode.Space)) {
                        moveJumping = true;
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
                        if (Input.GetKey(KeyCode.RightArrow)) { // if RIGHT ARROW was pressed, jump will go slightly right
                            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f, 0f), ForceMode2D.Impulse);
                            bounceRight = true;
                        }
                        if (Input.GetKey(KeyCode.LeftArrow)) { // if LEFT ARROW was pressed, jump will go slightly left
                            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3f, 0f), ForceMode2D.Impulse);
                            bounceLeft = true;
                        }
                    }
                }
                // when CAT hits right wall, can't move right
                if (GetComponent<Transform>().position.x >= 7.19f) {
                    moveSpeedRight = 0;
                }
                // when CAT isn't against right wall, can move right
                if (GetComponent<Transform>().position.x <= 7.19f) {
                    moveSpeedRight = 0.15f;
                }
                // when CAT hits left wall, can't move left
                if (GetComponent<Transform>().position.x <= -7.12) {
                    moveSpeedLeft = 0;
                }
                // when CAT isn't against left wall, can move left
                if (GetComponent<Transform>().position.x >= -7.12) {
                    moveSpeedLeft = 0.15f;
                }
                // CAT movement (left & right)
                if (moveLeftRight == true) {
                    // when LEFT ARROW pressed, CAT moves left
                    if (Input.GetKey(KeyCode.LeftArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - moveSpeedLeft,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                    }
                    // when RIGHT ARROW pressed, CAT moves right
                    if (Input.GetKey(KeyCode.RightArrow)) {
                        GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + moveSpeedRight,
                                                                         GetComponent<Transform>().position.y,
                                                                         GetComponent<Transform>().position.z);
                    }
                }
            }

            if (catDed == true) {
                gameObject.layer = 10;
            }
        }
    }
}
