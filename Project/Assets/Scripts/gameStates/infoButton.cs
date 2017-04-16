using UnityEngine;
using System.Collections;

public class infoButton : MonoBehaviour {

    public Sprite yes_button;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update () {

        Physics2D.IgnoreLayerCollision(16, 8);
        Physics2D.IgnoreLayerCollision(16, 9);
        Physics2D.IgnoreLayerCollision(16, 10);
        Physics2D.IgnoreLayerCollision(16, 11);
        Physics2D.IgnoreLayerCollision(16, 12);
        Physics2D.IgnoreLayerCollision(16, 13);
        Physics2D.IgnoreLayerCollision(16, 14);
        Physics2D.IgnoreLayerCollision(16, 15);
        Physics2D.IgnoreLayerCollision(16, 17);
        Physics2D.IgnoreLayerCollision(16, 18);

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(-1.56f, -6.3f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameTutorial == true) {
            GetComponent<SpriteRenderer>().sprite = yes_button;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true &&
            GameObject.Find("CreditButton").GetComponent<Transform>().position.y < -6.9) {
            GetComponent<TargetJoint2D>().maxForce = 200f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(-1.56f, -10f);
        }

        //if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
        //    GetComponent<TargetJoint2D>().maxForce = 800f;
        //    GetComponent<TargetJoint2D>().anchor = new Vector2(GetComponent<Transform>().position.x - 8.0f,
        //                                                       GetComponent<Transform>().position.y + 4.0f);
        //    GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.0f);
        //}
    }

    void OnMouseDown() {
        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().info_window_story;
            GameObject.Find("Window").GetComponent<Transform>().position = new Vector3(GameObject.Find("Window").GetComponent<Transform>().position.x,
                                                                                       0f,
                                                                                       GameObject.Find("Window").GetComponent<Transform>().position.z);
            GameObject.Find("ScrollButtonNext").GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.2f);
            GameObject.Find("ScrollButtonBack").GetComponent<TargetJoint2D>().target = new Vector2(-8f, -4.2f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameTutorial == true) {
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().info_window_story;
            GameObject.Find("Window").GetComponent<Transform>().position = new Vector3(GameObject.Find("Window").GetComponent<Transform>().position.x,
                                                                                       0f,
                                                                                       GameObject.Find("Window").GetComponent<Transform>().position.z);
            GameObject.Find("ScrollButtonNext").GetComponent<TargetJoint2D>().target = new Vector2(8f, -4.2f);
            GameObject.Find("ScrollButtonBack").GetComponent<TargetJoint2D>().target = new Vector2(-8f, -4.2f);

            GameObject.Find("StartButton").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("StartButton").GetComponent<startButton>().play_button;

            GetComponent<TargetJoint2D>().maxForce = 200f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(-1.56f, -10f);
        }
    }

    void OnMouseEnter() {
        if (GetComponent<Transform>().position.y <= -5.9f) {
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x,
                                                         GetComponent<Transform>().position.y + 0.5f,
                                                         GetComponent<Transform>().position.z);
        }
    }
}
