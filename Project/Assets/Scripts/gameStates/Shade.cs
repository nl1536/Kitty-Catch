using UnityEngine;
using System.Collections;

public class Shade : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0.6f);
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            if (GetComponent<SpriteRenderer>().color.a < 0.6) {
                GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f,
                                                                 GetComponent<SpriteRenderer>().color.a + 0.01f);
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            if (GetComponent<SpriteRenderer>().color.a > 0) {
                GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f,
                GetComponent<SpriteRenderer>().color.a - 0.05f);
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            if (GetComponent<SpriteRenderer>().color.a < 0.6) {
                GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f,
                                                                 GetComponent<SpriteRenderer>().color.a + 0.01f);
            }
        }
	
	}
}
