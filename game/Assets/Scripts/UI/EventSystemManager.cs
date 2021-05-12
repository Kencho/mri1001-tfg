using UnityEngine;
using UnityEngine.EventSystems;

namespace Platformer.UI
{
    public class EventSystemManager : MonoBehaviour
    {
        public EventSystem eventSystem;

        private void Awake()
        {
            eventSystem = GetComponent<EventSystem>();
        }

        private void OnEnable()
        {
            eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
        }

    }

}
