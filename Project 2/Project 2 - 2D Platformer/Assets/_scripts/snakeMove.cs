using UnityEngine;
using System.Collections;

public class snakeMove : MonoBehaviour {

	Rigidbody2D charRB;
	Transform charTransform;
	float hFactor;
	float hVelocity;
	float vVelocity;
	int direction = 1;
	public float jumpVal;
	public float leapVal;
	public float speed;
	public bool onGround = true;
	public bool moving = false;
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
		anim.SetBool ("moving", moving);
		//Add bools for left and right directions

		if (hFactor != 0f) {
			moving = true;
		} else {
			moving = false;
		}

		//Left-Right Tracking
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			direction = 0;
		}
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			direction = 1;
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
			hVelocity = leapVal;
		} else {
			vVelocity = 0;
			hVelocity = 0;
		}
		if (direction == 0)
			charRB.velocity += new Vector2 (-hVelocity, vVelocity);
		if (direction == 1)
			charRB.velocity += new Vector2 (hVelocity, vVelocity);
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
}
