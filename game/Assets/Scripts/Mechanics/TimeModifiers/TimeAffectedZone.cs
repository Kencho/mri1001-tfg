using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    public class TimeAffectedZone : MonoBehaviour
    {
        public float timeScaleAplied;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            TimeAfectedObject timeAfectedObj = collision.gameObject.GetComponent<TimeAfectedObject>();

            if(timeAfectedObj != null)
            {
                PlatformerModel.timeManager.ScaleTime(timeAfectedObj, timeScaleAplied);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            TimeAfectedObject timeAfectedObj = collision.gameObject.GetComponent<TimeAfectedObject>();

            if(timeAfectedObj != null)
            {
                PlatformerModel.timeManager.UnScaleTime(timeAfectedObj);
            }
        }
    }
}

