using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour {
    private GameObject myObject;
    public int moveSpeed = 230;
    private bool facingRight;
	// Use this for initialization
	void Start () {
        //get the direction
        myObject = GameObject.Find("mainCharacter");
        facingRight = myObject.GetComponent<PlayerMovement>().facingRight;
    }
	
	// Update is called once per frame
	void Update () {
        if (facingRight)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            Destroy(gameObject, 1);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            Destroy(gameObject, 1);
        }
        

     }
}
