using Platformer.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Resources
{
    public class PlayerTrigger : MonoBehaviour
    {
        private bool isTrigger;
        private Collider2D triggerZone;

        public bool IsTrigger { get => isTrigger; }

        private void Awake()
        {
            isTrigger = false;
            triggerZone = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.GetComponent<PlayerController>() != null)
            {
                isTrigger = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            isTrigger = false;
        }
    }

}
