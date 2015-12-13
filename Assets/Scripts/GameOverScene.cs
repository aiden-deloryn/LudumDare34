using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Final Score: " + Score.score.ToString ();
	}
}
