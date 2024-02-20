using UnityEngine;
using Mirror;

public class EndTurn : NetworkBehaviour{
    
    public GameObject playerArea;
    public GameObject card1;
    public GameObject gameManager;
    
    // Start is called before the first frame update
    private void Start()
    {
        playerArea = GameObject.Find("PlayerArea");
        gameManager = GameObject.Find("GameManager");
    }
    

    private NetworkIdentity GetIdentity()
    {
        return NetworkClient.connection.identity;
    }
  
    //todo change onclick function from EndTurn to OnClick
    // public void EndTurnButton()
    // {
    //     GetIdentity().GetComponent<Player>().isOnTurn = true;
    //     GameObject card = Instantiate(card1, new Vector3(0, 0, 0), Quaternion.identity);
    //     card.transform.SetParent(playerArea.transform, false);
    // }
    
    public void OnClick()
    {
        gameManager.GetComponent<GameManager>().EndTurn();
    }
}
