using UnityEngine;
using System.Collections;

public class startButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D() {
        Physics2D.IgnoreLayerCollision(16, 8);
        Physics2D.IgnoreLayerCollision(16, 9);
        Physics2D.IgnoreLayerCollision(16, 10);
        Physics2D.IgnoreLayerCollision(16, 11);
        Physics2D.IgnoreLayerCollision(16, 12);
        Physics2D.IgnoreLayerCollision(16, 13);
    }

    // Update is called once per frame
    void Update () {

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.0f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<TargetJoint2D>().maxForce = 200f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(8f, -10f);
        }

        //if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
        //    GetComponent<TargetJoint2D>().maxForce = 800f;
        //    GetComponent<TargetJoint2D>().anchor = new Vector2(GetComponent<Transform>().position.x - 8.0f,
        //                                                       GetComponent<Transform>().position.y + 4.0f);
        //    GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.0f);
        //}
    }

    void OnMouseDown() {
        GameObject.Find("Window").GetComponent<gameState>().gamePlay = true;
    }
}
