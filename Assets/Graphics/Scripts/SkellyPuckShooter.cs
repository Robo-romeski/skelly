using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyPuckShooter : MonoBehaviour
{
    Vector2 shotDirection;
	Rigidbody2D rb;

    bool isAiming = false; //We use this to check whether or not we're aiming our skelly puck
    bool isPreppingShot = false; //We use this to check if we're trying to figure how far our skelly puck is going to go
    bool lockShotMeter = false;
    bool puckShot = false;

    float shotMeter;
    float shotPower;
    
	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody2D> (); 
	}

    // Update is called once per frame
    void Update()
    {
        //We engage aiming mode if we click the LMB and we're not already aiming
        if (Input.GetMouseButtonDown(0) && isAiming == false && isPreppingShot == false)
        {
            shotMeter = 0;
            shotPower = 0;
            isAiming = true;
        }

        //We do setup for properly aiming the puck in a direction if we're in aiming mode
        if (isAiming)
        {
            //Convert mouse's current position into world space so we can aim properly
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Get the direction we're shooting in by using the mouse's position in world space as a reference point
            shotDirection = mouseWorldPos - (Vector2)transform.position;

            // If we press spacebar while we are aiming, then we are now in shooting charge mode
            if (Input.GetKeyDown(KeyCode.Space) && isPreppingShot == false)
            {
                lockShotMeter = false;
                isPreppingShot = true;
            }
        }

        // we run the charge meter if we haven't yet tried to shoot the puck
        if (isPreppingShot == true && lockShotMeter == false)
        {
		
			// Increase our shot meter as long as it's less than 1 (which we pretend is 100%)
            if (shotMeter < 1f)
            {
                shotMeter += Time.deltaTime;
            }

			// If our shot meter goes over 1, then reset it to 0
            else if (shotMeter >= 1f)
            {
                shotMeter = 0;
            }

			// Lock in our shot the moment we press spacebar again
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPreppingShot = false;
                lockShotMeter = true;
                shotPower = shotMeter;
                ShootPuck();
            }
        }
		
		//If we release the mouse button we can't aim or prep a shot anymore
        if (Input.GetMouseButtonUp(0))
        {
            isAiming = false;
            isPreppingShot = false;
        }
	}

    void ShootPuck()
    {
		Vector2 testVec = new Vector2 (5f, 5f); //Makes a new vector2 with the float values 5f and 5f along the x-y coordinate plane
		rb.AddForce (testVec, ForceMode2D.Impulse); //adds a force in the direction described by testVec above, as an Impulse
	
        // GetComponent<Rigidbody2D>().AddForce(shotDirection.normalized * shotPower);
    }
}