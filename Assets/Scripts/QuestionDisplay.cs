﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SimpleJSON;

public class QuestionDisplay : MonoBehaviour {

	public Protobowl pb;

	private float localTime = 0;
	private int localIndex = 0;
	public string disp = "";

	void Start(){
		StartCoroutine (UpdateDisp());
	}

	void InitDisp(){

		print ("init display");

		// init display
		var timePassed = pb.data ["real_time"] - pb.data ["time_offset"] - pb.data ["begin_time"];

		if (pb.state == Protobowl.GameState.BUZZED) {
			timePassed = pb.data ["time_freeze"] - pb.data ["begin_time"];
		}

		var accum = 0;
		var qList = pb.data ["question"].ToString ().Split (' ');
		List<int> timing = convertJSONToList (pb.data ["timing"].AsArray);
		for (int i = 0; i < timing.Count; i++) {
			localIndex = i;
			disp += qList + " ";
			accum += (int)Mathf.Round (timing [i] * pb.data ["rate"]);

			if (accum >= timePassed) {
				break;
			}
		}

		localTime = pb.data ["real_time"];

	}

	IEnumerator UpdateDisp(){
		// update display

		print (pb.state);

		// detect new question
		if (pb.state == Protobowl.GameState.NEW_Q) {
			pb.state = Protobowl.GameState.RUNNING;
			InitDisp ();
		}

		// run client-side display
		if (pb.state == Protobowl.GameState.RUNNING) {

			List<int> timing = convertJSONToList (pb.data ["timing"].AsArray);

			if (localIndex < timing.Count) {
				var qList = pb.data ["question"].ToString ().Split (' ');
				disp = string.Join (" ", qList.Take (localIndex + 1).ToArray ());

				var currentInterval = Mathf.Round (timing [localIndex] * pb.data ["rate"]);
				yield return new WaitForSeconds (currentInterval / 1000);
				localTime += currentInterval;
				localIndex++;
			}
		} else {
			pb.state = Protobowl.GameState.IDLE;
		}

		// auto-fill when question ends
		if (pb.state == Protobowl.GameState.IDLE) {
			disp = pb.data ["question"];
		}
	}

	private List<int> convertJSONToList(JSONArray arr){
		// converts json array to int list

		List<int> retList = new List<int> ();
		foreach (JSONNode element in arr) {
			retList.Add (element.AsInt);
		}
		return retList;
	}
}
