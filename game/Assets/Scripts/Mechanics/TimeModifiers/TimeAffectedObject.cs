using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    public abstract class TimeAffectedObject : MonoBehaviour
    {
        private float timeScale = TimeManager.DEFAULT_TIME_SCALE;

        public float TimeScale { get => timeScale;}

        protected abstract void Move();

        public virtual void SetTimeScale(float timeScale)
        {
            this.timeScale = timeScale;
        }

        public virtual void ResetTimeScale()
        {
            timeScale = TimeManager.DEFAULT_TIME_SCALE;
        }
    }
}

