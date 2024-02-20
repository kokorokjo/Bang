using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public List<GameObject> playersList = new();
    private int _playerOnTurnIndex = 0;

    private Player GetPlayerOnTurn()
    {
        Debug.Log("Players count3: " + playersList.Count);
        Debug.Log($"index: {_playerOnTurnIndex}");
        return playersList[_playerOnTurnIndex].GetComponent<Player>();
    }

    [Server]
    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    
    public void StartGame()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerTag");
        foreach (GameObject player in players)
        {
            playersList.Add(player);
        }
        StartTurn();
        Debug.Log("Players count1: " + playersList.Count);
        
    }
    

    public void StartTurn()
    {
        Player player = GetPlayerOnTurn();
        player.DrawCards();
        player.PlayCards();
        Debug.Log("Players count4: " + playersList.Count);

    }


    public void EndTurn()
    {
        Debug.Log("Players count2: " + playersList.Count);
        GetPlayerOnTurn().DiscardCards();
        
        if (_playerOnTurnIndex == playersList.Count - 1) _playerOnTurnIndex = 0;
        else _playerOnTurnIndex++;
        StartTurn();
    }
}
