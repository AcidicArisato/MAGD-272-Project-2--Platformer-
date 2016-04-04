using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiDisplay : MonoBehaviour {

	public Text score;
	public Text lives;
	public Text coins;

	void Start () {
		statsManager.lives = 3;
	}

	void Update () {

		//Tells UI to print out current values
		score.text = statsManager.score.ToString();
		lives.text = statsManager.lives.ToString();
		coins.text = statsManager.coins.ToString();

	}
}
