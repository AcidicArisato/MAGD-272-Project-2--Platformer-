using UnityEngine;
using System.Collections;

public class coinCollect : MonoBehaviour {

	//Remember to add sound!!

	void OnTriggerEnter2D(Collider2D col){

		if(col.CompareTag("Player")){
			statsManager.coins++;
			statsManager.score += 100;
			Destroy (gameObject);
		}
	}
}
