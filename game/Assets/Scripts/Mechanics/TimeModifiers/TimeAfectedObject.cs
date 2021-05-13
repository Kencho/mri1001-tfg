﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public abstract class TimeAfectedObject : MonoBehaviour
    {
        private float timeScale = 1;

        public float TimeScale { get => timeScale;}

        protected abstract void Move();

        public virtual void SetTimeScale(float timeScale)
        {
            this.timeScale = timeScale;
        }

        public virtual void ResetTimeScale()
        {
            timeScale = 1;
        }
    }
}

