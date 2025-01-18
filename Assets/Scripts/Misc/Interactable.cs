using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace LuciferGamingStudio
{
    public class Interactable : MonoBehaviour
    {
        public bool isInteractable;
        [SerializeField] private string defaultLayer;

        public UnityEvent OnInteract;

        public void SetFocus(bool check)
        {
            gameObject.layer = LayerMask.NameToLayer(check ? "Outline" : defaultLayer);
            foreach(Transform child in transform)
            {
                child.gameObject.layer = gameObject.layer;
            }
        }

        public virtual void Interact()
        {
            InputManager.Instance.canMove = false;
            OnInteract.Invoke();
        }
    }
}
