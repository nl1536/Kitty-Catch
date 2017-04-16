using UnityEngine;
using System.Collections;

public class catCounter : MonoBehaviour {

    public Sprite cat_counter_0;
    public Sprite cat_counter_1;
    public Sprite cat_counter_2;
    public Sprite cat_counter_3;
    public Sprite cat_counter_4;
    public Sprite cat_counter_5;
    public Sprite cat_counter_6;
    public Sprite cat_counter_7;
    public Sprite cat_counter_8;
    public Sprite cat_counter_9;
    public Sprite cat_counter_10;

	// Use this for initialization
	void Start () {

        GetComponent<SpriteRenderer>().sprite = cat_counter_0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 0) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_0;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 1) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_1;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 2) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_2;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 3) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_3;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 4) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_4;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 5) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_5;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 6) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_6;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 7) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_7;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 8) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_8;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 9) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_9;
        }

        if (GameObject.Find("Man").GetComponent<ManCatchCat>().catsCaught == 10) {
            GetComponent<SpriteRenderer>().sprite = cat_counter_10;
        }

    }
}
