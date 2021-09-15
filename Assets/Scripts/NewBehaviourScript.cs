using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject goal;
	NavMeshAgent agent;
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		InvokeRepeating("AiFindPlayer", 2f, 1.5f);
	}

	void AiFindPlayer(){
		agent.destination = goal.transform.position; 
	}
}
