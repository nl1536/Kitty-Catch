using UnityEngine;
using System.Collections;

public class creditWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D()
    {
        Physics2D.IgnoreLayerCollision(15, 8);
        Physics2D.IgnoreLayerCollision(15, 9);
        Physics2D.IgnoreLayerCollision(15, 10);
        Physics2D.IgnoreLayerCollision(15, 11);
        Physics2D.IgnoreLayerCollision(15, 12);
        Physics2D.IgnoreLayerCollision(15, 13);
        Physics2D.IgnoreLayerCollision(15, 14);
        Physics2D.IgnoreLayerCollision(15, 16);
    }

    // Update is called once per frame
    void Update () {

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(0f, -8.5f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<TargetJoint2D>().maxForce = 200f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(0f, -9.0f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(GetComponent<Transform>().position.x,
                                                               GetComponent<Transform>().position.y + 8.5f);
            GetComponent<TargetJoint2D>().target = new Vector2(0f, -8.5f);
        }
    }
}
