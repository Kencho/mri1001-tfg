using UnityEngine;
using UnityEngine.EventSystems;

namespace Platformer.UI
{
    /// <summary>
    /// Wrapper class used to ensure EventSystem will do the requiered intructions when enabled
    /// </summary>
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

        public void EnableInput()
        {
            eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
            eventSystem.sendNavigationEvents = true;
        }

        public void DisableInput()
        {
            eventSystem.sendNavigationEvents = false;
        }

    }

}
