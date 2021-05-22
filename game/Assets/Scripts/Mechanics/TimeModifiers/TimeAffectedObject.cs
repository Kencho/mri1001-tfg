using UnityEngine;

namespace Platformer.Mechanics.TimeModifiers
{
    /// <summary>
    /// Class of the objects that can be affected by time modifications
    /// </summary>
    public abstract class TimeAffectedObject : MonoBehaviour
    {
        private float timeScale = TimeManager.DEFAULT_TIME_SCALE;

        public float TimeScale { get => timeScale;}

        /// <summary>
        /// Perform movement according to TimeAffectedObjects features
        /// </summary>
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

