using UnityEngine;
using System.Collections;

public class birdMove : MonoBehaviour {

	Rigidbody2D charRB;
	Transform charTransform;
	bool flapWing = false;
	public float hFactor;
	public float vFactor;
	public float vVelocity;
	public float jumpVal;
	public float speed;
	public bool onGround = true;
	public int jumps;

	Animator anim;

	// Use this for initialization
	void Start () {

		charTransform = gameObject.transform;
		charRB = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("onGround", onGround);
		anim.SetBool ("flapWing", flapWing);

		vFactor = Input.GetAxis ("Vertical");
		Debug.Log (vFactor);
		//Horizontal Movement
		if (!onGround) {
			hFactor = Input.GetAxis ("Horizontal") * speed;
			charTransform.position = new Vector2 (hFactor + charTransform.position.x, charTransform.position.y);
			//anim.SetFloat ("hspeed", Mathf.Abs (hFactor));
			//anim.SetFloat ("vvelocity", charRB.velocity.y);
		}

		//Vertical Movement
		if (Input.GetKeyDown (KeyCode.Space)) { //Checks for Space key and limits number of jumps
			charRB.velocity = Vector2.zero;
			jumps++;
			vVelocity = jumpVal;
			flapWing = true;
		} else {
			vVelocity = 0;
			flapWing = false;
		}
		charRB.velocity += new Vector2 (0, vVelocity);

	}

	//Resets jumps
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Ground")){
			Debug.Log ("Touched Ground");
			onGround = true;
			anim.SetBool ("onground", onGround);
			jumps = 0;
		}

	}

	//Toggles onGround
	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Ground")){
			Debug.Log ("Left Ground");
			onGround = false;
			anim.SetBool ("onground", onGround);
			jumps = 1;
		}

	}
}
