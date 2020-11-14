using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour {

	public GameObject playerController;

	public AudioSource footsteps;

	public AudioSource bite;

	private float x;

	private float y;

	private float z;

	private float positionChangeInterval = 3;

	private float positionChangeCounter;

	private Animator animator;

	private bool isDead = false;

	Vector3 randomPos;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator>();
		animator.SetBool("isDead", false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			return;
		}
		positionChangeCounter = positionChangeCounter + Time.deltaTime;
		if (Vector3.Distance(playerController.transform.position, this.			transform.position) < 15) {
			Vector3 distanceDiff = playerController.transform.position - this.transform.position;

			distanceDiff.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distanceDiff), 1f * Time.deltaTime );

			this.transform.Translate(0, 0, 3.1f * Time.deltaTime);
		}
		else{
			if (positionChangeCounter > positionChangeInterval){
				positionChangeCounter = 0;
				x = Random.Range(2, 74);
				y = 1;
				z = Random.Range(2, 74);
				randomPos = new Vector3(x, y, z);
			}
				Vector3 distance = randomPos - this.transform.position;

				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(distance), 1f * Time.deltaTime );

				this.transform.Translate(0, 0, 2f * Time.deltaTime);
			
		}
	}
	void OnTriggerEnter(Collider other) {

		// trigger helicopter's explode function via HeliController component
		// and then destroy this airplane as well
		
		if (other.tag == "Bullet"){
			isDead = true;
			animator.SetBool("isDead", true);
			footsteps.Stop();
		}
		if (other.tag == "Player" && isDead == false){
			bite.Play();
			SceneManager.LoadScene("Death");
		}
	}
}
