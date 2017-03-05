using UnityEngine;
using System.Collections;

public class gameState : MonoBehaviour {

    public bool gameStart;
    public bool gamePlay;
    public bool gameWin;

	// Use this for initialization
	void Start () {

        gameStart = true;
        gamePlay = false;
        gameWin = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (gameStart == true) {
            
        }

	}
}
