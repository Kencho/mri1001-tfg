using Platformer.Mechanics.Player;
using UnityEngine;

namespace Platformer.Mechanics.Resources
{
    /// <summary>
    /// Class that checks if a PlayerController is located in the colliders area
    /// </summary>
    public class PlayerTrigger : MonoBehaviour
    {
        /// <summary>
        /// true if PlayerController inside the collider; false if no PlayerController isnside the collider
        /// </summary>
        private bool isTriggered;
        private Collider2D triggerZone;

        public bool IsTriggered { get => isTriggered; }

        private void Awake()
        {
            isTriggered = false;
            triggerZone = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<PlayerController>() != null)
            {
                isTriggered = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isTriggered = false;
        }
    }

}
