using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class TimeManager : MonoBehaviour
    {
        public const float DEFAULT_TIME_SCALE = 1;
        private List<TimeAfectedObject> timeAfectedObjects;

        private void Awake()
        {
            timeAfectedObjects = new List<TimeAfectedObject>();
        }

        public void ScaleTime(TimeAfectedObject timeAfectedObject, float timeScale)
        {
            timeAfectedObject.SetTimeScale(timeScale);
            timeAfectedObjects.Add(timeAfectedObject);
        }

        public void UnScaleTime(TimeAfectedObject timeAfectedObject)
        {
            if (timeAfectedObjects.Contains(timeAfectedObject))
            {
                ResetTimeScale(timeAfectedObject);
                timeAfectedObjects.Remove(timeAfectedObject);
            }
        }

        public void ResetTimeAfectedObjects()
        {
            foreach (TimeAfectedObject timeAfectedObj in timeAfectedObjects)
            {
                UnScaleTime(timeAfectedObj);
            }
            timeAfectedObjects = new List<TimeAfectedObject>();
        }

        public void ResetTimeScale(TimeAfectedObject timeAfectedObject)
        {
            timeAfectedObject.SetTimeScale(DEFAULT_TIME_SCALE);
        }

        public void ScaleGlobalTime(float timeScale, float timeModificationDuration = -1)
        {
            Time.timeScale *= timeScale;
            if (timeModificationDuration >= 0)
            {
                StartCoroutine(UnscaleGlobalTime(timeScale, timeModificationDuration));
            }
        }

        public void SetDefaultGlobalTime()
        {
            Time.timeScale = DEFAULT_TIME_SCALE;
        }

        private IEnumerator UnscaleGlobalTime(float timeScale, float timeModificationDuration)
        {
            yield return new WaitForSeconds(timeModificationDuration);
            ScaleGlobalTime(1 / timeScale);
        }
    }
}

