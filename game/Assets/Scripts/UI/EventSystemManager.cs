using UnityEngine;
using UnityEngine.EventSystems;

namespace Platformer.Sound
{
    /// <summary>
    /// Wrapper class used to ensure EventSystem will do the requiered intructions when enabled
    /// </summary>
    public class EventSystemManager : MonoBehaviour
    {
        public EventSystem eventSystem;
        private GameObject lastFrameSelectedObject;
        private AudioSource audioSource;
        public AudioClip changeButtonSound;

        private void Awake()
        {
            eventSystem = GetComponent<EventSystem>();
            audioSource = GetComponent<AudioSource>();
            lastFrameSelectedObject = eventSystem.firstSelectedGameObject; ;
        }

        private void Update()
        {
            if(lastFrameSelectedObject != eventSystem.currentSelectedGameObject)
            {
                audioSource.PlayOneShot(changeButtonSound);
            }
            lastFrameSelectedObject = eventSystem.currentSelectedGameObject;
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
