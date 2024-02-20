using UnityEngine;

namespace characters
{
    public class WilliTheKid : MonoBehaviour
    {
        public bool HasAbilityFor(string cardName)
        {
            return cardName == "Bang!";
        }

        public void Ability()
        {
            Debug.Log("Bang!");
        }
    }
}
