using UnityEngine;
using UnityEngine.UI;

namespace utils
{
    public class CardFlipper : MonoBehaviour
    {
        public Sprite cardFront;
        public Sprite cardBack;

        public void Flip()
        {
            Sprite currentSprite = gameObject.GetComponent<Image>().sprite;
            gameObject.GetComponent<Image>().sprite = currentSprite == cardFront ? cardBack : cardFront;
        }
    
        public bool IsCardFront()
        {
            return gameObject.GetComponent<Image>().sprite == cardFront;
        }
    }
}
