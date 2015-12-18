using UnityEngine;
using System.Collections;

public class SeguirPersonaje : MonoBehaviour {

	public GameObject player;
	public float x = 0.0f;
	public float y = 0.0f; 
	public float z = 0.0f;
	
	// Update is called once per frame
	void Update () {
		x = player.gameObject.transform.position.x;
		z = player.gameObject.transform.position.z;
		transform.position = new Vector2(x,z);
		Debug.Log (x);
		Debug.Log (y);
		Debug.Log (transform.position);
	}
}
