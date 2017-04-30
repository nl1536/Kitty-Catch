using UnityEngine;
using System.Collections;

public class ManCatchCat : MonoBehaviour {

    public GameObject Cat;

    public float catsCaught;

    public AudioClip cat_purr_sfx;

	// Use this for initialization
	void Start () {

        catsCaught = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (catsCaught >= 10) {
            GameObject.Find("Window").GetComponent<gameState>().gamePlay = false;
            GameObject.Find("Window").GetComponent<gameState>().gameWin = true;
        }
        else {
            GameObject.Find("Window").GetComponent<gameState>().gameWin = false;
        }

	}

    // when CAT hits MAN, CAT disappears
    void OnCollisionEnter2D(Collision2D catchCat) {
        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            if (catchCat.gameObject.tag == "totsNotDedCat") {
                catsCaught++;
                GetComponent<AudioSource>().PlayOneShot(cat_purr_sfx);
                GameObject.Find("CatCounter").GetComponent<Transform>().position = new Vector3(GameObject.Find("CatCounter").GetComponent<Transform>().position.x,
                                                                                               6.4f,
                                                                                               GameObject.Find("CatCounter").GetComponent<Transform>().position.z);
            }
        }
    }
    
    void savedCatTrue() {
        GameObject.FindWithTag("dedCat").GetComponent<Animator>().SetBool("Saved", true);
    }
}
