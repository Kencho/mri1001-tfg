using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    public class TimeManager : MonoBehaviour
    {
        public const float DEFAULT_TIME_SCALE = 1;
        private List<TimeAffectedObject> timeAffectedObjects;
        private Coroutine unscaledRoutine;

        private void Awake()
        {
            timeAffectedObjects = new List<TimeAffectedObject>();
        }

        public void ScaleTime(TimeAffectedObject timeAffectedObject, float timeScale)
        {
            timeAffectedObject.SetTimeScale(timeScale);
            timeAffectedObjects.Add(timeAffectedObject);
        }

        public void UnScaleTime(TimeAffectedObject timeAffectedObject)
        {
            if (timeAffectedObjects.Contains(timeAffectedObject))
            {
                ResetTimeScale(timeAffectedObject);
                timeAffectedObjects.Remove(timeAffectedObject);
            }
        }

        public void ResetAffectedObjects()
        {
            if(timeAffectedObjects.Count > 0)
            {
                foreach (TimeAffectedObject timeAffectedObj in timeAffectedObjects)
                {
                    ResetTimeScale(timeAffectedObj);
                }
            }
            timeAffectedObjects = new List<TimeAffectedObject>();
        }

        public void ResetTimeScale(TimeAffectedObject timeAffectedObject)
        {
            timeAffectedObject.SetTimeScale(DEFAULT_TIME_SCALE);
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

