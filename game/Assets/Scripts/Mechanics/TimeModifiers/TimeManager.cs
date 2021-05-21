using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    public class TimeManager : MonoBehaviour
    {
        public const float DEFAULT_TIME_SCALE = 1;
        private List<TimeAffectedObject> timeAfectedObjects;
        private Coroutine unscaledRoutine;

        private void Awake()
        {
            timeAfectedObjects = new List<TimeAffectedObject>();
        }

        public void ScaleTime(TimeAffectedObject timeAfectedObject, float timeScale)
        {
            timeAfectedObject.SetTimeScale(timeScale);
            timeAfectedObjects.Add(timeAfectedObject);
        }

        public void UnScaleTime(TimeAffectedObject timeAfectedObject)
        {
            if (timeAfectedObjects.Contains(timeAfectedObject))
            {
                ResetTimeScale(timeAfectedObject);
                timeAfectedObjects.Remove(timeAfectedObject);
            }
        }

        public void ResetTimeAfectedObjects()
        {
            if(timeAfectedObjects.Count > 0)
            {
                foreach (TimeAffectedObject timeAfectedObj in timeAfectedObjects)
                {
                    ResetTimeScale(timeAfectedObj);
                }
            }
            timeAfectedObjects = new List<TimeAffectedObject>();
        }

        public void ResetTimeScale(TimeAffectedObject timeAfectedObject)
        {
            timeAfectedObject.SetTimeScale(DEFAULT_TIME_SCALE);
        }

        public void ScaleGlobalTime(float timeScale, float timeModificationDuration = -1)
        {
            Time.timeScale *= timeScale;
            if (timeModificationDuration >= 0)
            {
                unscaledRoutine = StartCoroutine(UnscaleGlobalTime(timeScale, timeModificationDuration));
            }
        }

        public void SetDefaultGlobalTime()
        {
            if(unscaledRoutine != null)
            {
                StopCoroutine(unscaledRoutine);
            }
            Time.timeScale = DEFAULT_TIME_SCALE;
        }

        private IEnumerator UnscaleGlobalTime(float timeScale, float timeModificationDuration)
        {
            yield return new WaitForSeconds(timeModificationDuration);
            ScaleGlobalTime(1 / timeScale);
        }
    }
}

