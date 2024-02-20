using UnityEngine;

namespace cards
{
    public class Card : MonoBehaviour
    {
        public string cardName;
        public string type;
    
  
        public void PlayCard(GameObject card)
        {
            switch (cardName)
            {
                case "Bang!":
                    Debug.Log("Bang!");
                    card.GetComponent<Bang>().PlayCard(card);
                    break;
                default: 
                    Debug.Log("Default");
                    break;
            }
        }
    }
}
