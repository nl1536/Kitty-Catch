using UnityEngine;
using System.Collections;

public class gameState : MonoBehaviour {

    public bool gameStartWin;
    public bool gameStart;
    public bool gamePlay;
    public bool gameWin;

	// Use this for initialization
	void Start () {

        gameStartWin = true;
        gameStart = true;
        gamePlay = false;
        gameWin = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (gamePlay == true) {
            gameStart = false;
        }

        if (gameStartWin == true) {
            if (gameWin == true) {
                gameStart = false;
            }

            if (gameStart == true) {
                gamePlay = false;
                gameWin = false;
            }
        }
        
        // WINDOW moves down to center of screen at START of game
        if (gameStart == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(GetComponent<Transform>().position.x,
                                                               GetComponent<Transform>().position.y);
            GetComponent<TargetJoint2D>().target = new Vector2(0f, 0f);
        }
        // WINDOW moves up out of view during GAMEPLAY
        if (gamePlay == true) {
            GetComponent<TargetJoint2D>().maxForce = 200f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(0f, 15f);
        }
        // WINDOW moves down to center of screen at END of game
        if (gameWin == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(GetComponent<Transform>().position.x,
                                                               GetComponent<Transform>().position.y);
            GetComponent<TargetJoint2D>().target = new Vector2(0f, 0f);
        }
    }
}
