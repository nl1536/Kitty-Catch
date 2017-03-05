using UnityEngine;
using System.Collections;

public class helicopterChopCat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // if HELICOPTER hits CAT it kills CAT
    void OnCollisionEnter2D(Collision2D chopCat)
    {
        if (chopCat.gameObject.tag == "totsNotDedCat") {
            chopCat.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
