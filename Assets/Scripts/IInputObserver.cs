using UnityEngine;
using System.Collections;

public interface IInputObserver {
	void ButtonPressed(InputButton button);
	void ButtonReleased(InputButton button);
}
