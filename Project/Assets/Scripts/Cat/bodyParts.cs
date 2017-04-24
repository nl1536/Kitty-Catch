using UnityEngine;
using System.Collections;

public class bodyParts : MonoBehaviour {

    float rotateSpeed;

	// Use this for initialization
	void Start () {

        rotateSpeed = Random.Range(10f, 20f);
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

        if (GetComponent<Transform>().position.x <= GameObject.Find("Helicopter").GetComponent<Transform>().position.x) {
            GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation - rotateSpeed);
        }

        if (GetComponent<Transform>().position.x > GameObject.Find("Helicopter").GetComponent<Transform>().position.x) {
            GetComponent<Rigidbody2D>().MoveRotation(GetComponent<Rigidbody2D>().rotation + rotateSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D noRotate) {
        if (noRotate.gameObject.name == "Ground") {
            if (rotateSpeed > 0f) {
                rotateSpeed = rotateSpeed - 3f;
            }
        }
    }

    void OnCollisionStay2D(Collision2D noRotate) {
        if (noRotate.gameObject.name == "Ground") {
            if (rotateSpeed > 0f) {
                rotateSpeed = rotateSpeed - 3f;
            }
            if (rotateSpeed <= 0f) {
                rotateSpeed = 0f;
            }
        }
    }
}
