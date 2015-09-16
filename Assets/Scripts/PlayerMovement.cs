using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		KeyboardControllPlayer ();
	}

	public void KeyboardControllPlayer()
	{
		if(Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
		{ transform.position = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);   }

		if(Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
		{ transform.position = new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z);   }

		if(Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
		{ transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1);   }

		if(Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
		{ transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 1);   }
	}

	public void JoystickControllPlayer()
	{

	}

}
