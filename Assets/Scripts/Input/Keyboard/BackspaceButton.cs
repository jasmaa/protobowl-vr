using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackspaceButton : MonoBehaviour {
	/// <summary>
	/// VR keyboard backspace
	/// </summary>
	
	public Keyboard keyboard;

	void Start () {
		keyboard = transform.parent.GetComponent<Keyboard> ();

		GetComponent<Button> ().onClick.AddListener(() => {
			keyboard.Backspace();
		});
	}

}
