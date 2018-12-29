﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour {
	// VR keyboard key

	public string mainChar;
	public string shiftChar;
	public string currChar;
	public Keyboard keyboard;

	void Start(){
		keyboard = transform.parent.GetComponent<Keyboard> ();

		GetComponent<Button> ().onClick.AddListener(() => {
			keyboard.text += currChar;
			keyboard.SetShift(false);
		});
	}

	public void Init(){
		currChar = mainChar;
		transform.GetChild(0).GetComponent<Text> ().text = currChar;
	}

	public void SetShift(bool shift){
		currChar = shift ? shiftChar : mainChar;
		transform.GetChild(0).GetComponent<Text> ().text = currChar;
	}
}