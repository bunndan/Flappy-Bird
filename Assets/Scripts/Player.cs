using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Force to have the plyer jump
	public Vector2 jumpForce = new Vector2(0, 300);

	// Update is called once per frame
	void Update () {
		// Jump
		if (Input.GetKeyUp ("space")) {
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(jumpForce);
		}

		// Die when the player leaves the screen
		Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
		// transform holds the position, rotation, and scale of whatever GameObject 
		// the script is attached to.
		if (screenPosition.y > Screen.height || screenPosition.y < 0) {
				Die ();
		}
	}

	// Die when the player collides
	void OnCollisionEnter2D() {
		Die();
	}

	void Die() {
		// Reload the current level/scene that Unity has open
		Application.LoadLevel (Application.loadedLevel);
	}
}
