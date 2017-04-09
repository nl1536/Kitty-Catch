using UnityEngine;
using System.Collections;

public class catDie : MonoBehaviour {

    bool killedByDog;

    public AudioClip cat_die_sfx;

	// Use this for initialization
	void Start () {

        GetComponent<Animator>().SetBool("Dead", false);
        GetComponent<Animator>().SetBool("DieGroundBounce", false);

        killedByDog = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter2D(Collision2D catCollide) {
        if (GetComponent<CatMovement>().catDed == false) {
            // if CAT hits GROUND then it dies and a NEW CAT is put in play
            if (catCollide.gameObject.name == "Ground") {
                GetComponent<Animator>().SetTrigger("DieGround");
                GetComponent<Animator>().SetBool("Dead", true);
                GetComponent<CatMovement>().moveJumping = false;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                Instantiate(GameObject.Find("blood_splatter_ground"), new Vector3(GetComponent<Transform>().position.x,
                                                                                  GetComponent<Transform>().position.y,
                                                                                  GetComponent<Transform>().position.z), Quaternion.identity);
                GetComponent<AudioSource>().PlayOneShot(cat_die_sfx);
                GetComponent<CatMovement>().catDed = true;
            }
            // if CAT hits MAN then NEW CAT appears
            if (catCollide.gameObject.tag == "RunningMan") {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CatMovement>().catDed = true;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                GameObject.Find("Man").GetComponent<Animator>().SetTrigger("Catch");
            }
            // if CAT hits HELICOPTER then it dies and NEW CAT appears
            if (catCollide.gameObject.tag == "chopper") {
                GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Helicopter").GetComponent<AudioSource>().PlayOneShot(
                    GameObject.Find("Helicopter").GetComponent<helicopterMovement>().helicopter_kill_sfx);
                GetComponent<CatMovement>().catDed = true;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                Instantiate(GameObject.Find("cat_die_head"), new Vector3(GameObject.Find("Helicopter").GetComponent<Transform>().position.x + Random.Range(-3f, 3f),
                                                                         GameObject.Find("Helicopter").GetComponent<Transform>().position.y,
                                                                         0f), Quaternion.identity);
                Instantiate(GameObject.Find("cat_die_fur_large"), new Vector3(GameObject.Find("Helicopter").GetComponent<Transform>().position.x + Random.Range(-3f, 3f),
                                                                         GameObject.Find("Helicopter").GetComponent<Transform>().position.y,
                                                                         0f), Quaternion.identity);
                GameObject.Find("Helicopter").GetComponent<Animator>().SetBool("Kill", true);
            }
            // if CAT hits DOG then it dies and NEW CAT appears
            if (catCollide.gameObject.tag == "Dog") {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, 5f, 0f), ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<CatMovement>().catDed = true;
                killedByDog = true;
                Instantiate(GetComponent<CatMovement>().Cat, new Vector3(0f, 5.2f, 0f), Quaternion.identity);
                GameObject.Find("Dog").GetComponent<Animator>().SetTrigger("Kill");
                GameObject.Find("Dog").GetComponent<Animator>().SetBool("hasKilled", true);
            }
        }
        if (GetComponent<CatMovement>().catDed == true) {
            // DEAD CATS don't collide with ALIVE CAT or other DEAD CATS or MAN
            Physics2D.IgnoreLayerCollision(10, 10);
            Physics2D.IgnoreLayerCollision(10, 11);
            Physics2D.IgnoreLayerCollision(10, 12);

            if (catCollide.gameObject.name == "Ground") {
                if (GetComponent<Renderer>().enabled == false && killedByDog == false) {
                    Destroy(gameObject);
                }
                else if (GetComponent<Animator>().GetBool("Dead") == true) {
                    GetComponent<Animator>().SetTrigger("DieGround");

                    if (GetComponent<CatMovement>().bounceLeft == true) {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-0.5f, 0f), ForceMode2D.Impulse);
                    }
                    if (GetComponent<CatMovement>().bounceRight == true) {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.5f, 0f), ForceMode2D.Impulse);
                    }
                }
                else if (GetComponent<Animator>().GetBool("Dead") == false) {
                    if (GetComponent<SpriteRenderer>().enabled == false) {
                        GetComponent<Transform>().position = new Vector3(GameObject.Find("Dog").GetComponent<Transform>().position.x,
                                                                     GetComponent<Transform>().position.y,
                                                                     GetComponent<Transform>().position.z);
                    }
                    GetComponent<SpriteRenderer>().enabled = true;
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    GetComponent<Animator>().SetBool("DieDogBounce", false);
                }
            }
        }
        }

    void OnCollisionStay2D(Collision2D catCollideStay) {
        if (catCollideStay.gameObject.name == "Ground") {
            GetComponent<Animator>().SetBool("DieGroundBounce", false);
            GetComponent<Animator>().SetBool("DieDogBounce", false);
        }
    }

    void OnCollisionExit2D(Collision2D catCollideExit) {
        if (catCollideExit.gameObject.name == "Ground") {
            GetComponent<Animator>().SetBool("DieGroundBounce", true);
            GetComponent<Animator>().SetBool("DieDogBounce", true);
        }
    }
}
