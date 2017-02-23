using UnityEngine;
using System.Collections;

public class gameWin : MonoBehaviour {

    public bool win;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        GameObject.Find("screenStart").GetComponent<startGame>().start = true;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 20f), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D startScreenCollide) {
        Physics2D.IgnoreLayerCollision(14, 8);
        Physics2D.IgnoreLayerCollision(14, 9);
        Physics2D.IgnoreLayerCollision(14, 10);
        Physics2D.IgnoreLayerCollision(14, 11);
        Physics2D.IgnoreLayerCollision(14, 12);
        Physics2D.IgnoreLayerCollision(14, 13);
        Physics2D.IgnoreLayerCollision(14, 15);
    }

    // INSERT WIN CONDITION HERE

    void OnTriggerEnter2D(Collider2D startScreenTrigger) {
        if (startScreenTrigger.gameObject.tag == "screenTrigger") {
            win = false;
        }
    }
}
