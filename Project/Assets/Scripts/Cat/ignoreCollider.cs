using UnityEngine;
using System.Collections;

public class ignoreCollider : MonoBehaviour {

    public bool buildingCollider;

	// Use this for initialization
	void Start () {

        buildingCollider = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            if (buildingCollider == true) {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true ||
            GameObject.Find("Window").GetComponent<gameState>().gameTutorial == true ||
            GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
