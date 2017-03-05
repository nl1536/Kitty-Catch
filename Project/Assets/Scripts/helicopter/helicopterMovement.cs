using UnityEngine;
using System.Collections;

public class helicopterMovement : MonoBehaviour {

    bool chopperGoRight;
    bool chopperGoLeft;

    float moveSpeed;

	// Use this for initialization
	void Start () {

        gameObject.GetComponent<Renderer>().enabled = false;

        chopperGoLeft = false;
        chopperGoRight = false;

        moveSpeed = 0.05f;
    }
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<Renderer>().enabled = false;
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<Renderer>().enabled = true;

            // when the MAN catches three CATS, the HELICOPTER appears
            if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught >= 3) {
                if (GetComponent<Transform>().position.x <= -14f) {
                    chopperGoRight = true;
                    chopperGoLeft = false;
                }
                if (GetComponent<Transform>().position.x >= 14f) {
                    chopperGoRight = false;
                    chopperGoLeft = true;
                }
            }
            // the more CATS the MAN catches, the faster the HELICOPTER speed
            if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 3) {
                moveSpeed = 0.05f;
            }
            if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 5) {
                moveSpeed = 0.1f;
            }
            if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 7) {
                moveSpeed = 0.15f;
            }
            if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 9) {
                moveSpeed = 0.2f;
            }

            if (chopperGoRight == true) {
                gameObject.GetComponent<Renderer>().enabled = true;
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x + moveSpeed,
                                                                 GetComponent<Transform>().position.y,
                                                                 GetComponent<Transform>().position.z);
            }

            if (chopperGoLeft == true) {
                gameObject.GetComponent<Renderer>().enabled = true;
                GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x - moveSpeed,
                                                                 GetComponent<Transform>().position.y,
                                                                 GetComponent<Transform>().position.z);
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            GetComponent<Transform>().position = new Vector3(-14.02f, 0f, GetComponent<Transform>().position.z);
            GetComponent<Renderer>().enabled = false;
        }
    }
}
