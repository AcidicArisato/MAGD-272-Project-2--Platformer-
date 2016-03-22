using UnityEngine;
using System.Collections;

public class characterMove : MonoBehaviour {

	Rigidbody2D charRB;
	Transform charTransform;
	float hFactor;
	float vVelocity;
	public float jumpVal;
	public float speed;
	public bool onGround = true;
	public int jumps;


	// Use this for initialization
	void Start () {

		charTransform = gameObject.transform;
		charRB = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		//Horizontal Movement
		hFactor = Input.GetAxis ("Horizontal") * speed;
		charTransform.position = new Vector2 (hFactor + charTransform.position.x, charTransform.position.y);

		//Vertical Movement
		if (Input.GetKeyDown (KeyCode.Space) && onGround == true && jumps == 0) { //Checks for Space key and limits number of jumps
			jumps++;
			vVelocity = jumpVal;
		} else if (Input.GetKeyDown (KeyCode.Space) && jumps == 1) {
			jumps++;
			vVelocity = jumpVal;

		} else {
			vVelocity = 0;
		}
		charRB.velocity += new Vector2 (0, vVelocity);


	}

	//Resets jumps
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Ground")){
			Debug.Log ("Touched Ground");
			onGround = true;
			jumps = 0;
		}

	}

	//Toggles onGround
	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Ground")){
			Debug.Log ("Left Ground");
			onGround = false;
		}

	}
}
