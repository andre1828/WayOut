using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject Player;
    [SerializeField] private MapGenerator mapgenerator;
    [SerializeField] private GameObject Scenelight;
    [SerializeField] private AudioClip[] audios;

    void Start()
    {
        audios = new AudioClip[0];
        mapgenerator = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>();
        // Scenelight = GameObject.FindGameObjectWithTag("SceneLight");
        SpawnPlayer();
        StartCoroutine(LightsOut());
        SetIsRespawnToFalse();
    }
    void Update () {

	}

    public void SpawnPlayer()
    {
        Instantiate(Player, mapgenerator.ReturnPlayerPosition(), Quaternion.identity);
        SetIsRespawnToFalse();
    }

    private IEnumerator LightsOut()
    {
        yield return new WaitForSeconds(3.8f);
        
    }

    public void SetIsRespawnToTrue()
    {
        Player.GetComponent<PlayerMovement>().IsRespawn = true;
    }

    public void SetIsRespawnToFalse()
    {
        Player.GetComponent<PlayerMovement>().IsRespawn = false;
    }
}
