using UnityEngine;
using System.Collections;

public class SkelltyopPuckScript : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> (); //Teklls script to find a rigidbody 2d component on the object that the script is attached to, then assign that component to the variable rb.
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			testPhysics();
		}

		if (rb.velocity.x > 0f) {
			crappyFrictSim();
		}
	}

	void testPhysics()
	{
		Vector2 testVec = new Vector2 (5f, 5f); //Makes a new vector2 with the float values 5f and 5f along the x-y coordinate plane
		rb.AddForce (testVec, ForceMode2D.Impulse); //adds a force in the direction described by testVec above, as an Impulse
	}

	void crappyFrictSim()
	{
		Vector2 dongs = new Vector2 (-1f, -1f);
		rb.AddForce (dongs, ForceMode2D.Force);
	}
}
