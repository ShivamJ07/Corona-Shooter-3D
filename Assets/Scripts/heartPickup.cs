using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heartPickup : MonoBehaviour {

	public AudioSource backGround;

	public AudioSource pickupSound;

	// Use this for initialization
	void OnTriggerEnter(Collider other) {

		// trigger helicopter's explode function via HeliController component
		// and then destroy this airplane as well
		if (other.tag == "Player" ){
			pickupSound.Play();
			SceneManager.LoadScene("Victory");
		}
	}
}
