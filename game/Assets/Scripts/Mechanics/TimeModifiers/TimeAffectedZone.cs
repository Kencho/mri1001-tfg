using Platformer.Model;
using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    /// <summary>
    /// Class with a collider. When a TimeAffectedObject enters the colliders zone TimeAffectedZone will scale its time
    /// </summary>
    public class TimeAffectedZone : MonoBehaviour
    {
        /// <summary>
        /// Time modification applied to TimeAffectedObjects
        /// </summary>
        public float timeScaleApplied;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TimeAffectedObject timeAffectedObj = collision.gameObject.GetComponent<TimeAffectedObject>();

            if(timeAffectedObj != null)
            {
                PlatformerModel.timeManager.ScaleTime(timeAffectedObj, timeScaleApplied);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TimeAffectedObject timeAffectedObj = collision.gameObject.GetComponent<TimeAffectedObject>();

            if(timeAffectedObj != null)
            {
                PlatformerModel.timeManager.UnScaleTime(timeAffectedObj);
            }
        }
    }
}

