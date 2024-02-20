using Mirror;
using UnityEngine;

namespace cards
{
    public class Bang : MonoBehaviour
    {
        public int id = 0;

        public string symbol;
        public int number;
        

        public void PlayCard(GameObject card)
        {
            Debug.Log("Bang");
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            Player player = networkIdentity.GetComponent<Player>();
            
        }
    }
}
