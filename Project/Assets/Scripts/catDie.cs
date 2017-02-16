using UnityEngine;
using System.Collections;

public class catDie : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D catCollide)
    {
        if (GetComponent<CatMovement>().catDed == false)
        {
            // if CAT hits GROUND then it dies and a NEW CAT is put in play
            if (catCollide.gameObject.name == "Ground")
            {
                GetComponent<CatMovement>().moveJumping = false;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0.05f, 3.09f, 0f), Quaternion.identity);
                GetComponent<CatMovement>().catDed = true;
            }
            // if CAT hits MAN then NEW CAT appears
            if (catCollide.gameObject.tag == "RunningMan")
            {
                GetComponent<CatMovement>().catDed = true;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0.05f, 3.09f, 0f), Quaternion.identity);
            }
            // if CAT hits HELICOPTER then it dies and NEW CAT appears
            if (catCollide.gameObject.tag == "Helicopter")
            {
                GetComponent<CatMovement>().catDed = true;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0.05f, 3.09f, 0f), Quaternion.identity);
            }
        }
        if (GetComponent<CatMovement>().catDed == true)
        {
            // DEAD CATS don't collide with ALIVE CAT or other DEAD CATS or MAN
            Physics2D.IgnoreLayerCollision(10, 10);
            Physics2D.IgnoreLayerCollision(10, 11);
            Physics2D.IgnoreLayerCollision(10, 12);

            if (catCollide.gameObject.name == "Ground")
            {
                if (GetComponent<CatMovement>().bounceLeft == true)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0f), ForceMode2D.Impulse);
                }
                if (GetComponent<CatMovement>().bounceRight == true)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0f), ForceMode2D.Impulse);
                }
            }
        }
    }
}
