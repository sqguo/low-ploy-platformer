using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerColliding : MonoBehaviour {
	public GameObject player;
	public GameObject respawn; 
	private GameObject door;
	Collider a, b;
	PlayerScript ps;
	// Use this for initialization
	void Start () {
		a = player.GetComponent<Collider> (); 
		ps = player.GetComponent<PlayerScript> ();
	}

	void Update(){
		if (ps.isOver == false) {
			if (door != null) {
				if (a.bounds.Intersects (b.bounds)) {
					if (ps.doorkey == true&& ps.canTrasverse == true) {
						player.transform.position = door.GetComponent<doorScript> ().exit.transform.position; 
						//player.transform.eulerAngles = door.GetComponent<doorScript> ().exit.transform.eulerAngles;
						ps.canTrasverse = false;
					}
				} 
			}	
		}
	}
		
	void OnTriggerEnter(Collider hit)
	{
		if (ps.isOver == false) {
			if (hit.gameObject.CompareTag ("door")) {
				door = hit.gameObject; 
				b = door.GetComponent<Collider> ();
				ps.sendMessage2 = "press 'Space' to enter nearby tunnel"; 
			}
			if (hit.gameObject.CompareTag ("pickup")) {
				hit.gameObject.SetActive (false); 
				ps.points++; 
			}
			if (hit.gameObject.CompareTag ("enemy")) {
				ps.textUpdate (); 
				ps.sendMessage2 = "careful, stay away from the ghosts" +
					"\tpress 'space' to restart";
				ps.sendMessage = "YOU DIED";
				ps.isOver = true; 
			}
			if (hit.gameObject.CompareTag ("Fall")) {
				ps.textUpdate (); 
				ps.sendMessage2 = "careful, don't fall";
				ps.sendMessage = "YOU DIED";
				ps.isOver = true; 
			}
			if (hit.gameObject.CompareTag ("key")) {
				ps.keys++; 
				ps.points += 5;
				ps.textUpdate (); 
				if (ps.keys == 5) {
					ps.sendMessage2 = "proceed to the gate";
				}
				hit.gameObject.SetActive (false); 
			}
			if (hit.gameObject.CompareTag ("gate")) {
				if(ps.keys >=5){
					ps.isOver = true;
					ps.sendMessage = "YOU WON"; 
				}
				else{
					ps.sendMessage2 = "you need 5 KEYS to open the GATE"; 
				}
			}
			ps.textUpdate (); 	
		}
	}
}
