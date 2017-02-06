using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    bool moveLeftRight;
    bool moveJump;
    bool moveJumping;

    float moveSpeedRight;
    float moveSpeedLeft;

	// Use this for initialization
	void Start () {

        moveLeftRight = false;
        moveJump = false;
        moveJumping = false;

        moveSpeedRight = 0.15f;
        moveSpeedLeft = 0.15f;
	
	}

    // Update is called once per frame
    void Update()
    {
        // when CAT hits BUILDING, can move left & right
        if (moveJumping == false) {
            moveLeftRight = true;
        }
        else {
            moveLeftRight = false;
        }
        // when CAT is on top of BUILDING, can jump
        if (GetComponent<Transform>().position.y >= 2.57f &&
            GetComponent<Transform>().position.y <= 2.65f) {
            moveJump = true;
        }
        // CAT doesn't bounce when on top of BUILDING
        if (GetComponent<Transform>().position.y > 2.5f)
        {
            GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 0f;
        }
        // makes BUILDING BOX COLLIDER 2D =/= trigger
        if (GetComponent<Transform>().position.y <= 2f) {
            GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = true;
            GetComponent<BoxCollider2D>().sharedMaterial.bounciness = 0.5f;
        }
        // when CAT hits right wall, can't move right
        if (GetComponent<Transform>().position.x >= 7.19f) {
        moveSpeedRight = 0;
        }
        // when CAT isn't against right wall, can move right
        if (GetComponent<Transform>().position.x <= 7.19f)
        {
            moveSpeedRight = 0.15f;
        }
        // when CAT hits left wall, can't move left
        if (GetComponent<Transform>().position.x <= -7.12) {
            moveSpeedLeft = 0;
        }
        // when CAT isn't against left wall, can move left
        if (GetComponent<Transform>().position.x >= -7.12)
        {
            moveSpeedLeft = 0.15f;
        }
        // CAT movement (left & right)
        if (moveLeftRight == true) { 
            // when LEFT ARROW pressed, CAT moves left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - moveSpeedLeft,
                                                                 GetComponent<Transform>().position.y,
                                                                 GetComponent<Transform>().position.z);
            }
            // when RIGHT ARROW pressed, CAT moves right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + moveSpeedRight,
                                                                 GetComponent<Transform>().position.y,
                                                                 GetComponent<Transform>().position.z);
            }
        }
        // CAT movement (jump)
        if (moveJump == true) {
            // when SPACEBAR pressed, CAT jumps off BUILDING
            if (Input.GetKeyDown(KeyCode.Space)) {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 4f), ForceMode2D.Impulse);
            }
        }
        // when SPACEBAR pressed, CAT cannot jump anymore & BUILDING BOX COLLIDER 2D = trigger
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveJump = false;
            moveJumping = true;
            GameObject.Find("centerBuilding").GetComponent<ignoreCollider>().buildingCollider = false;
        }
    }
}
