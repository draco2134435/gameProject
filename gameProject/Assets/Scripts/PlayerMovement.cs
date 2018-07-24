using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement: MonoBehaviour {

	[SerializeField] private Transform groundCheck;
	[SerializeField] private Transform ceilingCheck;
	public float jumpForce = 5000f;
	public float maxSpeed = 10f;
	public bool facingRight = true;
	private Rigidbody2D rigBody;
	private float lastDistance;
	private LayerMask environmentLayerMask;

	void awake(){
		
	}
	void start(){
		
	}

	void FixedUpdate(){
		environmentLayerMask = LayerMask.GetMask ("Environment");
		rigBody = GetComponent<Rigidbody2D>();
		float move = Input.GetAxis("Horizontal");
		rigBody.velocity = new Vector2 (move * maxSpeed, rigBody.velocity.y);
		if (move > 0 && !facingRight) {
			flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}
		float jumpAxis = Input.GetAxisRaw ("Jump");
		if (jumpAxis != 0 && rigBody.velocity.y <= 0) {
			RaycastHit2D hit2D = Physics2D.Raycast (rigBody.position - new Vector2 (0f, 0.5f), Vector2.down, 0.2F, environmentLayerMask);

			if (hit2D) {
				Debug.Log ("Hello1");
				if (hit2D.distance < lastDistance) {
					lastDistance = hit2D.distance;
				} else {
					Debug.Log ("Hello");
					lastDistance = 100f;
					jump (jumpAxis * jumpForce * Time.deltaTime);
				}
			}
		}
	}
	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
	void jump(float force){
		if (jumpForce < 0) {
			return;
		}
		rigBody.AddForce (new Vector2 (0, force));
	}
}
