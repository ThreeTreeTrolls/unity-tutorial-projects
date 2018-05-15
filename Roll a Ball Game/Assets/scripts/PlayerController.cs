using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public Text countText;
	public Text winText;
	public AudioSource sfx;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()//called before physics calculations, physics code
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement*speed);
	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
			sfx.Play ();

		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();

		if (count >= 8) {
			winText.text = "winner, winner, chicken dinner.";
		}
	}
}
