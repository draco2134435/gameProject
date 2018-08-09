using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {
	public float fireRate = 0f;
	public float dmg = 10f;
	public LayerMask notToHit;
	float timeToFire = 0f;
    public PlayerMovement playerMovemet;
    public bool facingRight = false;
	public Transform firePoint;
    public Transform bulletPrefab;

	// Use this for initialization
	void awake(){
        

	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
	}
	void FixedUpdate () {
        facingRight = playerMovemet.facingRight;
        //aims gun
        if (facingRight)
        {
            if (Input.GetButton("Vertical"))
            {

                transform.eulerAngles = new Vector3(0f, 0f, 90f * Input.GetAxisRaw("Vertical"));
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        else
        {
            if (Input.GetButton("Vertical"))
            {

                transform.eulerAngles = new Vector3(0f, 0f, -90f * Input.GetAxisRaw("Vertical"));
            }
            else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
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
        effect();
	}
    void effect()
    {
        
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.Log("There is no bullet");
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
        
    }
}
