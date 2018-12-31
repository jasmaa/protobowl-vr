using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour {
	/// <summary>
	/// VR keyboard enter button, submits keyboard input as guess to server
	/// </summary>
	
	public Keyboard keyboard;

	void Start () {
		keyboard = transform.parent.GetComponent<Keyboard> ();

		GetComponent<Button> ().onClick.AddListener(() => {
			GameManager.instance.client.pb.Guess(keyboard.text, true);
			keyboard.ClearText();
			keyboard.gameObject.SetActive(false);
		});
	}

}
