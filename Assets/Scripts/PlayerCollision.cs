using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        try
        {
            gameController.SetIsRespawnToTrue();
            gameController.SpawnPlayer();
        }
        catch (System.Exception)
        {

            Debug.Log("nope, spawn problem");
        }
    }    
}
