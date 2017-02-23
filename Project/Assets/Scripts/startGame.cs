using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {

    public bool start;

	// Use this for initialization
	void Start () {

        start = true;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown() {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D startScreenCollide) {
        Physics2D.IgnoreLayerCollision(13, 8);
        Physics2D.IgnoreLayerCollision(13, 9);
        Physics2D.IgnoreLayerCollision(13, 10);
        Physics2D.IgnoreLayerCollision(13, 11);
        Physics2D.IgnoreLayerCollision(13, 12);
        Physics2D.IgnoreLayerCollision(13, 14);
        Physics2D.IgnoreLayerCollision(13, 15);

        if (startScreenCollide.gameObject.tag == "screenCollider") {
            start = true;
        }
    }

    void OnTriggerEnter2D(Collider2D startScreenTrigger) {
        if (startScreenTrigger.gameObject.tag == "screenTrigger") {
            start = false;
        }
    }
}
