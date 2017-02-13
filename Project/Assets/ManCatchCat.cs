using UnityEngine;
using System.Collections;

public class ManCatchCat : MonoBehaviour {

    public GameObject Cat;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // when CAT hits MAN, CAT disappears
    void OnCollisionEnter2D(Collision2D catchCat)
    {
        if (catchCat.gameObject.tag == "totsNotDedCat")
        {
            catchCat.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
