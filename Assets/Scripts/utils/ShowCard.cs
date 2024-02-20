using UnityEngine;
using UnityEngine.UI;

namespace utils
{
    public class ShowCard : MonoBehaviour
    {
        public GameObject canvas;
        public GameObject zoomCard;
        public bool canBeZoomed = true;
    
        private GameObject _zoomCard;
        private Sprite _sprite;
        private void Awake()
        {
            canvas = GameObject.Find("Canvas");
            _sprite = gameObject.GetComponent<Image>().sprite;
        }

        public void OnPointerEnter()
        {
            if (!canBeZoomed) return;
        
            Debug.Log("Enter");
            Vector3 gameObjectPosition = gameObject.transform.position;
            Vector2 position = new Vector2(gameObjectPosition.x, gameObjectPosition.y + 100);
            _zoomCard = Instantiate(zoomCard, position, Quaternion.identity);
            _zoomCard.GetComponent<Image>().sprite = _sprite;
            _zoomCard.transform.SetParent(canvas.transform, true);
        
            RectTransform rectTransform = _zoomCard.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(85, (float)129.75);
        }

        public void OnPointerExit()
        {
            Debug.Log("Exit");
            Destroy(_zoomCard);
        }
    }
}
