using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	[SerializeField]
	GameController gameController;
	[SerializeField]
	GameObject explosion;

	private AudioSource _frogSound;

	// Use this for initialization
	void Start () {
		_frogSound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//add score if avatar collides with frog
	//minus life if avatar collides with rock
	public void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag.Equals ("frog")) {
			Debug.Log ("Collide frog\n");
			Destroy (other.gameObject.GetComponent<FrogController>());
			if (_frogSound != null) {
				_frogSound.Play ();
			}
			Player.Instance.Score += 100;
		} else if (other.gameObject.tag.Equals ("rock")) {
			Debug.Log ("Collide rock\n");

			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<RockController> ().Reset ();
			Player.Instance.Life -= 1;
		}
	}
}
