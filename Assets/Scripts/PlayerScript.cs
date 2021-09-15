using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerScript : MonoBehaviour
{ 
	private CharacterController controller;
	public float speed = 10f;
	public float turnSpeed  = 90;
	private Vector3 velocity;
	private Vector3 velocity2; 
	private Vector3 lastPosition;
	public bool doorkey;
	public bool canTrasverse; 
	public int points; 
	public byte keys; 
	public bool isOver; 
	public Text pointText;
	public Text keyText; 
	public Text message; 
	public Text hint; 
	public string sendMessage;
	public string sendMessage2; 
	public GameObject displayed; 
	void Start()
	{
		controller = GetComponent<CharacterController>();
		doorkey = false; 
		canTrasverse = true; 
		points = 0; 
		keys = 0; 
		isOver = false;
		sendMessage = "";
		sendMessage2 = "collect 5 KEYS and escape through the GATE"; 
		textUpdate (); 
		//InvokeRepeating("timedRotate", 0.5f, 0.5f);
		//lastPosition = displayed.transform.position; 
	}

	//public void timedRotate(){
	//	displayed.transform.rotation = Quaternion.Euler (displayed.transform.position-lastPosition);
	//	lastPosition = displayed.transform.position; 
	//}

	public void textUpdate(){
		pointText.text = "Score: " + points; 
		keyText.text = "Keys Obtained: " + keys;
		hint.text = sendMessage2; 
		message.text = sendMessage; 
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			if (isOver == true) {
				restartlevel (); 
			}
			doorkey = true; 
		} 
		if(Input.GetKeyUp(KeyCode.Space)) {
			doorkey = false; 
			canTrasverse = true; 
		}

	}
	void FixedUpdate(){
		if (isOver == false) {
			velocity = transform.forward * -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
			controller.SimpleMove(velocity);
			velocity2 = transform.right* Input.GetAxis("Vertical") * speed * Time.deltaTime;
			controller.SimpleMove(velocity2);
		}
	}

	void restartlevel(){
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
	}


}