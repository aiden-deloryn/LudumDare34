using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {
	public AudioClip enemyHitSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Enemy enemy = other.gameObject.GetComponent<Enemy> ();
		
		if (enemy != null) {
			GetComponent<AudioSource>().PlayOneShot(enemyHitSound);
			Destroy (enemy.gameObject);
			Destroy(this.gameObject, 0.1f);
		}
	}
}
