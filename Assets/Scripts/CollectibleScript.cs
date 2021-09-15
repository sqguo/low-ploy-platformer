using UnityEngine;
using System.Collections;

public class CollectibleScript : MonoBehaviour {

	void Update () 
	{
		transform.Rotate (new Vector3 (30, 45, 15) * Time.deltaTime);
	}
}