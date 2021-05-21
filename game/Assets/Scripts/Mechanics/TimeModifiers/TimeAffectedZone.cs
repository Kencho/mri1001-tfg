using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    public class TimeAffectedZone : MonoBehaviour
    {
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

