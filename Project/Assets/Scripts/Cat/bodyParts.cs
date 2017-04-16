using UnityEngine;
using System.Collections;

public class bodyParts : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
	
	// Update is called once per frame
	void Update () {
        
        Physics2D.IgnoreLayerCollision(10, 8);
        Physics2D.IgnoreLayerCollision(10, 10);
        Physics2D.IgnoreLayerCollision(10, 11);
        Physics2D.IgnoreLayerCollision(10, 12);
        Physics2D.IgnoreLayerCollision(10, 13);
        Physics2D.IgnoreLayerCollision(10, 14);
        Physics2D.IgnoreLayerCollision(10, 15);
        Physics2D.IgnoreLayerCollision(10, 16);
        Physics2D.IgnoreLayerCollision(10, 17);
        Physics2D.IgnoreLayerCollision(10, 18);
        Physics2D.IgnoreLayerCollision(10, 19);

        // GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(.01f, .05f), 0f, Random.Range(0.01f, .05f)), ForceMode2D.Impulse);

    }
}
