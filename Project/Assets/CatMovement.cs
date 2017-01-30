using UnityEngine;
using System.Collections;

public class CatMovement : MonoBehaviour {

    bool moveLeftRight;
    float moveSpeedRight;
    float moveSpeedLeft;

	// Use this for initialization
	void Start () {

        moveSpeedRight = 0.15f;
        moveSpeedLeft = 0.15f;
	
	}

    // Update is called once per frame
    void Update()
    {
        // when CAT hits BUILDING, can move left & right
        if (GetComponent<Transform>().position.y <= 2.58f) {
            moveLeftRight = true;
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

    }
}
