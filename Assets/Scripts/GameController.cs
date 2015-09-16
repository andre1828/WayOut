using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject Player;
    [SerializeField] private MapGenerator mapgenerator;
    void Start()
    {
        mapgenerator = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>();
    }

	void Update () {

	}

    public void SpawnPlayer()
    {
       Instantiate(Player, mapgenerator.ReturnPlayerPosition(), Quaternion.identity);
    }
}
