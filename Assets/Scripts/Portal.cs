using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
	public string linkedLevel = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<Player> () == null)
			return;

		if (linkedLevel == "") {
			// game completed
		} else {
			Application.LoadLevel (linkedLevel);
		}
	}
}
