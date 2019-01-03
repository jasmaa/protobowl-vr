using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// VR keyboard backspace
/// </summary>
public class BackspaceButton : MonoBehaviour {
	
	public Keyboard keyboard;

	void Start () {
		keyboard = transform.parent.GetComponent<Keyboard> ();

		GetComponent<Button> ().onClick.AddListener(() => {
			keyboard.Backspace();
		});
	}

}
