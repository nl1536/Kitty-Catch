using UnityEngine;
using System.Collections;

public class sideBuildingIgnoreCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // sideBuildingLeft
        Physics2D.IgnoreLayerCollision(14, 8); // "Dog"
        Physics2D.IgnoreLayerCollision(14, 9); // "Background"
        Physics2D.IgnoreLayerCollision(14, 10); // "DedCats"
        Physics2D.IgnoreLayerCollision(14, 12); // "RunningMan"
        Physics2D.IgnoreLayerCollision(14, 13); // "Window"
        Physics2D.IgnoreLayerCollision(14, 16); // "Button"
        Physics2D.IgnoreLayerCollision(14, 17); // "centerBuilding"
        Physics2D.IgnoreLayerCollision(14, 18); // "helicopter"

        // sideBuildingRight
        Physics2D.IgnoreLayerCollision(15, 8); // "Dog"
        Physics2D.IgnoreLayerCollision(15, 9); // "Background"
        Physics2D.IgnoreLayerCollision(15, 10); // "DedCats"
        Physics2D.IgnoreLayerCollision(15, 12); // "RunningMan"
        Physics2D.IgnoreLayerCollision(15, 13); // "Window"
        Physics2D.IgnoreLayerCollision(15, 16); // "Button"
        Physics2D.IgnoreLayerCollision(15, 17); // "centerBuilding"
        Physics2D.IgnoreLayerCollision(15, 18); // "helicopter"
    }
}
