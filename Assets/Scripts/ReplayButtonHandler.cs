using UnityEngine;
using System.Collections;

public class ReplayButtonHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		Score.score = 0f;
		Application.LoadLevel ("Level1");
	}
}
