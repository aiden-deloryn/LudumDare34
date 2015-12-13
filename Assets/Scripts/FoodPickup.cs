using UnityEngine;
using System.Collections;

public class FoodPickup : MonoBehaviour {
	float Size {
		get {
			return (this.gameObject.transform.localScale.x + this.gameObject.transform.localScale.y);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other) {
		Player player = other.gameObject.GetComponent<Player> ();

		if (player != null) {
			//if ((player.transform.localScale.x + player.transform.localScale.y) < (transform.localScale.x + transform.localScale.y)) return;
			player.Grow(Size);
			this.GetComponent<AudioSource>().Play();
			Destroy (this.gameObject, 0.1f);
		}
	}
}
