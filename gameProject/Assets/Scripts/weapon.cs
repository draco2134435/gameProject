using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
	public float fireRate = 0f;
	public float dmg = 10f;
	public LayerMask notToHit;
	public bool facingRight = true;

	float timeToFire = 0f;
	Transform firePoint;
	// Use this for initialization
	void awake(){
		firePoint = transform.Find ("firePoint");
		if (firePoint == null) {
			Debug.Log ("There is no firepoint");
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
	}
	void FixedUpdate () {
		
		if (Input.GetButton ("Vertical")) {	
			
			transform.eulerAngles = new Vector3 (0f, 0f, 90f * Input.GetAxisRaw ("Vertical"));
		} else {
			transform.eulerAngles = new Vector3 (0f, 0f, 0f);
		}

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire3")) {
				shoot ();
			}
		} else {
			//add for cooldown.
		}

	}

	void shoot(){
		Debug.Log ("Shooting is working");
	}
}
