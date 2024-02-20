using cards;
using Mirror;
using UnityEngine;

namespace utils
{
    public class DragDrop : NetworkBehaviour
    {
    
        private bool _isDragging = false;
        private bool _isOverDropZone = false;
        private bool _isDraggable = true;
        private Vector2 _startPosition;
        private GameObject _startParent;
        private GameObject _dropZone;
        // Start is called before the first frame update
        void Start()
        {
       
        }

        // Update is called once per frame
        private void Update()
        {
            if (_isDragging)
            {
                transform.position = Input.mousePosition;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            _isOverDropZone = true;
            _dropZone = col.gameObject;
            Debug.Log("collision");
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _isOverDropZone = false;
            _dropZone = null;
            Debug.Log("no collision");
        }


        public void StartDrag()
        {
            if (!_isDraggable) return;
        
            Transform transform1 = transform;
            _startPosition = transform1.position;
            _startParent = transform1.parent.gameObject;
            _isDragging = true;
            gameObject.GetComponent<ShowCard>().canBeZoomed = false;
        }
        
        
        
        public void EndDrag()
        {
            Player player = NetworkClient.connection.identity.GetComponent<Player>();
            
            _isDragging = false;
            if (_isOverDropZone && player.isOnTurn)
            {
                transform.SetParent(_dropZone.transform, false);
                gameObject.transform.position = _dropZone.transform.position;
           
                if (_dropZone.CompareTag("Discard"))
                {
                    Debug.Log("discard");
                    gameObject.GetComponent<Card>().PlayCard(gameObject);
                    _isDraggable = false;
                }
                else if (_dropZone.CompareTag("Table"))
                {
                    Debug.Log("table");
                
                }

            }
            else
            {
                transform.position = _startPosition;
                transform.SetParent(_startParent.transform, false);
            }
            gameObject.GetComponent<ShowCard>().canBeZoomed = true;
        }
    }
}
