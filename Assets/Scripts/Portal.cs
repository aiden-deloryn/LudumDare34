using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

		Text levelCompleteText = GameObject.FindGameObjectWithTag("LevelCompleteText").GetComponent<Text>();
		Text scoreText = GameObject.FindGameObjectWithTag("LevelScoreText").GetComponent<Text>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		levelCompleteText.enabled = true;
		scoreText.enabled = true;
		float score = Mathf.Floor (player.transform.localScale.x + player.transform.localScale.y);
		scoreText.text = "Score: " + score.ToString ();
		Score.score += score;

		GameObject.Find ("InputManager").GetComponent<InputManager> ().enabled = false;
		Camera.main.GetComponent<SmoothFollowObject> ().target = this.gameObject;
		Destroy (player.gameObject);

		GetComponent<AudioSource> ().Play ();

		StartCoroutine (LoadNextLevel ());
	}

	IEnumerator LoadNextLevel() {
		yield return new WaitForSeconds (5.0f);
		Application.LoadLevel (linkedLevel);
	}
}
