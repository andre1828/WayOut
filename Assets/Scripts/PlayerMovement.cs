using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] float speed;
    public bool  CanMove;
    public bool IsRespawn;
    [SerializeField] private MapGenerator mapgenerator;

    [SerializeField] private float XboundaryLeft ;
    [SerializeField] private float XboundaryRight ;
    [SerializeField] private float YboundaryDown;
    [SerializeField] private float YboundaryUp ;

    // Use this for initialization
    void Start() {
        mapgenerator = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>();

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
        KeyboardControllPlayer();
       
        float XboundaryLeft = -((mapgenerator.width - 1) / 2f);
        float XboundaryRight = ((mapgenerator.width - 1) / 2f);
        float YboundaryDown = -((mapgenerator.height - 1) / 2f);
        float YboundaryUp = ((mapgenerator.height - 1) / 2f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, XboundaryLeft, XboundaryRight),
                                        .5f,
                                        Mathf.Clamp(transform.position.z, YboundaryDown, YboundaryUp));
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



 
}


    