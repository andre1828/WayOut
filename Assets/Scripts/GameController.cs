﻿using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

    [SerializeField] private GameObject Player;
    [SerializeField] private MapGenerator mapgenerator;
    [SerializeField] private GameObject Scenelight;
    [SerializeField] private Camera Camera;
    [SerializeField] private AudioClip[] audios;
    
    void Start()
    {   
        mapgenerator = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>();
        Camera.transform.position = new Vector3(0, (mapgenerator.width * 1.5f), 0);
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
        Camera.backgroundColor = Color.black;
       
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
