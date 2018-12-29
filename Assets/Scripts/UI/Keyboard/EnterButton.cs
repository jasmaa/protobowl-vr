using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterButton : MonoBehaviour {
	// VR keyboard submit button for answering
	public Keyboard keyboard;

	void Start () {
		keyboard = transform.parent.GetComponent<Keyboard> ();

		GetComponent<Button> ().onClick.AddListener(() => {
			GameManager.instance.client.pb.Guess(keyboard.text);
			keyboard.text = "";
			keyboard.gameObject.SetActive(false);
		});
	}

}
