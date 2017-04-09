using UnityEngine;
using System.Collections;

public class ManCatchCat : MonoBehaviour {

    public GameObject Cat;

    public float catsCaught;

	// Use this for initialization
	void Start () {

        catsCaught = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (catsCaught == 10) {
            GameObject.Find("Window").GetComponent<gameState>().gamePlay = false;
            GameObject.Find("Window").GetComponent<gameState>().gameWin = true;
        }

	}

    // when CAT hits MAN, CAT disappears
    void OnCollisionEnter2D(Collision2D catchCat) {
        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            if (catchCat.gameObject.tag == "totsNotDedCat"){
                catsCaught++;
            }
        }
    }
    
    void savedCatTrue() {
        GameObject.FindWithTag("dedCat").GetComponent<Animator>().SetBool("Saved", true);
    }
}
