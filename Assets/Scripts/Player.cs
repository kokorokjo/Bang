using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using utils;



public class Player : NetworkBehaviour
{
    public bool isOnTurn = false;
    public string playerName;
    public List<GameObject> handCards = new();
    public List<GameObject> tableCards = new();
    public int lifePoints;
    public GameObject character;
    public GameObject role;

    public GameObject playerArea;
    public GameObject deckGameObject;

    public List<Ability> Abilities = new();

    public override void OnStartClient()
    {
        base.OnStartClient();
        deckGameObject = GameObject.Find("Deck");
        playerArea = GameObject.Find("PlayerArea");
    }

    // public void EndTurn()
    // {
    //     gameObject.GetComponent<GameManager>().EndTurn();
    // }

    public void DrawCards()
    {
        //todo shuffle discard deck when deck is empty
        for (int i = 0; i < 2; i++)
        {
            Deck deck = deckGameObject.GetComponent<Deck>();
            Debug.Log(deck.cards.Count);
            GameObject card = deck.cards[0];
            handCards.Add(card);
            CmdSpawnCard();
            
            deck.cards.RemoveAt(0);
        }
    }

    [Command]
    private void CmdSpawnCard()
    {
        RpcSpawnCard();
    }

    [ClientRpc]
    private void RpcSpawnCard()
    {
        if (hasAuthority)
        {
            Debug.Log($"no. of cards in deck: {deckGameObject.GetComponent<Deck>().cards.Count}");
            GameObject card = Instantiate(deckGameObject.GetComponent<Deck>().cards[0], transform.position, Quaternion.identity);
            NetworkServer.Spawn(card, connectionToClient);
            card.transform.SetParent(playerArea.transform, false);
        }
    }

    public void PlayCards()
    {
        isOnTurn = true;
    }
    
    public void DiscardCards()
    {
        //todo discard cards   
        
        isOnTurn = false;
    }
    
    public void ChooseTarget()
    {
        
    }
}