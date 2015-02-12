using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	private int count;
	public GUIText countText;
	public GUIText winText;

	void Start() {
		count = 0;
		setCountText ();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		var deltaForce = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce(deltaForce * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		var gameObject = other.gameObject;
		if (gameObject.tag == "PickUp") {
			gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}

	void setCountText ()
	{
		countText.text = "Count : " + count.ToString();
		if (count >= 13) {
			winText.text = "YOU WIN!!";
		}

	}
}
