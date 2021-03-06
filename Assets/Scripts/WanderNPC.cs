using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Wandering non-opponent robo-avatar
/// </summary>
public class WanderNPC : MonoBehaviour {

	private Animator ani;
	private NavMeshAgent agent;

	private Vector3 destination;

	void Start () {
		FindDestination (15);
		transform.position = destination;

		ani = transform.GetChild(0).GetComponent<Animator> ();
		ani.Play ("RoboAvatar_Idle", 0, Random.value);

		agent = GetComponent<NavMeshAgent> ();
		agent.Warp (transform.position);
	}

	void Update () {

		if (agent.remainingDistance < 0.1f) {
			FindDestination (15);
			agent.SetDestination (destination);

			transform.GetChild(0).LookAt (destination);
		}
	}

	void FindDestination(float radius){
		var temp = Random.insideUnitSphere * radius;
		NavMeshHit hit;

		if (NavMesh.SamplePosition (temp, out hit, radius, 1)) {
			destination = hit.position;
		}
	}
}
