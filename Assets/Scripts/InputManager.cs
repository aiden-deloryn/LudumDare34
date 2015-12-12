using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InputButton {
	Up,
	Down,
	Left,
	Right,
	Jump,
	Shoot
}

public class InputManager : MonoBehaviour {

	private List<IInputObserver> observers = new List<IInputObserver>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// UP
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Up);
			}
		}

		if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Up);
			}
		}

		// DOWN
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Down);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Down);
			}
		}

		// LEFT
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Left);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Left);
			}
		}

		// RIGHT
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Right);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Right);
			}
		}

		// JUMP
		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed (InputButton.Jump);
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Jump);
			}
		}

		// SHOOT
		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed (InputButton.Shoot);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Shoot);
			}
		}
	}

	public void AddObserver(IInputObserver observer) {
		observers.Add (observer);
	}
	
	public void RemoveObserver(IInputObserver observer) {
		observers.Remove (observer);
	}
}
