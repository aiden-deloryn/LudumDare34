﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InputButton {
	Up,
	Down,
	Left,
	Right,
	Jump,
	ShootUp,
	ShootDown,
	ShootLeft,
	ShootRight
}

public class InputManager : MonoBehaviour {

	private List<IInputObserver> observers = new List<IInputObserver>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// UP
		if (Input.GetKeyDown (KeyCode.W)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Up);
			}
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Up);
			}
		}

		// DOWN
		if (Input.GetKeyDown (KeyCode.S)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Down);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.S)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Down);
			}
		}

		// LEFT
		if (Input.GetKeyDown (KeyCode.A)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Left);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.A)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased (InputButton.Left);
			}
		}

		// RIGHT
		if (Input.GetKeyDown (KeyCode.D)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.Right);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.D)) {
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

		// SHOOT UP
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.ShootUp);
			}
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased(InputButton.ShootUp);
			}
		}

		// SHOOT DOWN
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.ShootDown);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased(InputButton.ShootDown);
			}
		}

		// SHOOT LEFT
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.ShootLeft);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased(InputButton.ShootLeft);
			}
		}

		// SHOOT RIGHT
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonPressed(InputButton.ShootRight);
			}
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) {
			foreach (IInputObserver observer in observers) {
				observer.ButtonReleased(InputButton.ShootRight);
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
