using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject playerPrefab;
    public WorldData worldData = new WorldData();

    public static Dictionary<string, PlayerManager> players = new Dictionary<string, PlayerManager>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exits");
            Destroy(this);
        }
    }

    public void SpawnPlayer(PlayerData newPlayer)
    {
        Debug.Log($"Creating {newPlayer.id}");

        GameObject _player = Instantiate(playerPrefab, newPlayer.getPosition(), newPlayer.getRotation());
        _player.GetComponent<PlayerManager>().id = newPlayer.id;
        players.Add(newPlayer.id, _player.GetComponent<PlayerManager>());
        Debug.Log($"Players = {players.Count}");
    }

    void Update()
    {
        foreach (PlayerData onlinePlayer in worldData.clients)
        {
            if (onlinePlayer.id != ConnectionManager.instance.id) {
                if (players.ContainsKey(onlinePlayer.id))
                {
                    GameController.players[onlinePlayer.id].transform.position = onlinePlayer.getPosition();
                }
                else
                {
                    GameController.instance.SpawnPlayer(onlinePlayer);
                }
            }
        }
    }
}