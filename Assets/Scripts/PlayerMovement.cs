using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float speed;
    public bool  CanMove;
    public bool IsRespawn;

    // Use this for initialization
    void Start() {
        if (!IsRespawn)
        {
            StartCoroutine(FreezeUntilStart());
        }
        else
        {
            CanMove = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		KeyboardControllPlayer ();
	}

	public void KeyboardControllPlayer()
	{
        if (CanMove == true)
        {

            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
            { transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z); }

            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            { transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z); }

            if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow)))
            { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1); }

            if (Input.GetKeyDown(KeyCode.S) || (Input.GetKeyDown(KeyCode.DownArrow)))
            { transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1); }
        }
	}

	public void JoystickControllPlayer()
	{

	}

    public IEnumerator FreezeUntilStart()
    {
        yield return new WaitForSeconds(3.8f);
        CanMove = true;
    }

    public void MoveAfterRespawn()
    {
        if (IsRespawn)
        {
            CanMove = true;
            IsRespawn = false;
        }
    }
}
