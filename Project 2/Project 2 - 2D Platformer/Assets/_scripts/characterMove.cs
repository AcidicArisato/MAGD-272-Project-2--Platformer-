using UnityEngine;
using System.Collections;

public class characterMove : MonoBehaviour {

	Rigidbody2D charRB;
	Transform charTransform;
	float hFactor;
	float vVelocity;
	public float jumpVal;
	public float speed;
	public int jumps;
	public bool onGround = true;
	public bool moving = false;
	public bool facingRight;

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
		anim.SetBool ("moving", moving);

		if (hFactor != 0f) {
			moving = true;
		} else {
			moving = false;
		}

		//Horizontal Movement
		hFactor = Input.GetAxis ("Horizontal") * speed;
		charTransform.position = new Vector2 (hFactor + charTransform.position.x, charTransform.position.y);
		//anim.SetFloat ("hspeed", Mathf.Abs(hFactor));
		//anim.SetFloat ("vvelocity", charRB.velocity.y);

		//Vertical Movement
		if (Input.GetKeyDown (KeyCode.Space) && jumps == 0 && onGround) { //Checks for Space key and limits number of jumps
			jumps++;
			vVelocity = jumpVal;
		} else if (Input.GetKeyDown (KeyCode.Space) && jumps == 1) {
			charRB.velocity = Vector2.zero;
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
			anim.SetBool ("onGround", onGround);
			jumps = 0;
		}

	}

	//Toggles onGround
	void OnTriggerExit2D(Collider2D col){
		if(col.CompareTag("Ground")){
			Debug.Log ("Left Ground");
			onGround = false;
			anim.SetBool ("onGround", onGround);
			jumps = 1;
		}

	}

	/*void flip(){

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1.0f;
		transform.localScale = theScale;
	}*/
}
