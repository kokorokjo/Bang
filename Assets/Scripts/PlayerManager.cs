using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using utils;

public class PlayerManager : NetworkBehaviour
{
    public void ChooseTarget()
    {
        CmdChooseTarget();
    }

    [Command]
    private void CmdChooseTarget()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        GameManager gameManager = networkIdentity.GetComponent<GameManager>();
    
    }

    public void MoveCard(GameObject card, GameObject where, bool front = true)
    {
        CmdMoveCard(card, where, front);
    }

    [Command]
    private void CmdMoveCard(GameObject card, GameObject where, bool front)
    {
        RpcMoveCard(card, where, front);
    }

    [ClientRpc]
    private void RpcMoveCard(GameObject card, GameObject where, bool front)
    {
        card.transform.SetParent(where.transform, false);
        card.transform.position = where.transform.position;
        CardFlipper flipper = card.GetComponent<CardFlipper>();
        if (front && !flipper.IsCardFront()) flipper.Flip();
        
    }
}
