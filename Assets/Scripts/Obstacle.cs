using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public Vector2 velocity = new Vector2(-4, 0);
	public float range = 4;

	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = velocity;
		transform.position = new Vector3 (transform.position.x, transform.position.y - range * Random.value, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		// Delete the obstacle when it leaves the screen on the left.
		// Use the width of the main visible camera area as the boundary
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		if (screenPosition.x < -Screen.width) {
			Destroy(gameObject);
		}
	}
}
