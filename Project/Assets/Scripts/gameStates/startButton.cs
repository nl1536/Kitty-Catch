using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class startButton : MonoBehaviour {

    public Sprite no_button;
    public Sprite play_button;
    public Sprite play_again_button;

    public AudioClip button_hover_sfx;
    public AudioClip button_click_sfx;

	// Use this for initialization
	void Start () {

        GetComponent<SpriteRenderer>().sprite = play_button;
	
	}

    // Update is called once per frame
    void Update () {

        Physics2D.IgnoreLayerCollision(16, 8);
        Physics2D.IgnoreLayerCollision(16, 9);
        Physics2D.IgnoreLayerCollision(16, 10);
        Physics2D.IgnoreLayerCollision(16, 11);
        Physics2D.IgnoreLayerCollision(16, 12);
        Physics2D.IgnoreLayerCollision(16, 13);
        Physics2D.IgnoreLayerCollision(16, 14);
        Physics2D.IgnoreLayerCollision(16, 15);
        Physics2D.IgnoreLayerCollision(16, 17);
        Physics2D.IgnoreLayerCollision(16, 18);

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(6.82f, -6.28f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameTutorial == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(6.82f, -6.28f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gamePlay == true) {
            GetComponent<TargetJoint2D>().maxForce = 200f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(6.82f, -10f);
        }

        if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            GetComponent<TargetJoint2D>().maxForce = 800f;
            GetComponent<TargetJoint2D>().anchor = new Vector2(0f, 0f);
            GetComponent<TargetJoint2D>().target = new Vector2(6.82f, -6.28f);
            GetComponent<SpriteRenderer>().sprite = play_again_button;
        }
    }

    void OnMouseDown() {
        GetComponent<AudioSource>().PlayOneShot(button_click_sfx);

        if (GameObject.Find("Window").GetComponent<gameState>().gameStart == true) {
            GameObject.Find("Window").GetComponent<Transform>().position = new Vector3(GameObject.Find("Window").GetComponent<Transform>().position.x,
                                                                                       0f,
                                                                                       GameObject.Find("Window").GetComponent<Transform>().position.z);
            GameObject.Find("Window").GetComponent<gameState>().gameTutorial = true;
            GameObject.Find("Window").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Window").GetComponent<gameState>().tutorial_window;
            GetComponent<SpriteRenderer>().sprite = no_button;
        }
        else if (GameObject.Find("Window").GetComponent<gameState>().gameTutorial == true) {
            GameObject.Find("ScrollButtonNext").GetComponent<TargetJoint2D>().target = new Vector2(11f, -4.2f);
            GameObject.Find("ScrollButtonBack").GetComponent<TargetJoint2D>().target = new Vector2(-11f, -4.2f);
            GameObject.Find("Window").GetComponent<gameState>().gamePlay = true;
        }
        else if (GameObject.Find("Window").GetComponent<gameState>().gameWin == true) {
            SceneManager.LoadScene("Gameplay");
        }
    }

    void OnMouseEnter() {
        GetComponent<AudioSource>().PlayOneShot(button_hover_sfx);
        if (GetComponent<Transform>().position.y <= -5.9f) {
            GetComponent<Transform>().position = new Vector3(GetComponent<Transform>().position.x,
                                                         GetComponent<Transform>().position.y + 0.5f,
                                                         GetComponent<Transform>().position.z);
        }
    }
}
