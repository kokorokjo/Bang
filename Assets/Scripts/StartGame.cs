using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class StartGame : NetworkBehaviour
{
    public void OnClick()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.StartGame();
        Destroy(gameObject);
    }
}
