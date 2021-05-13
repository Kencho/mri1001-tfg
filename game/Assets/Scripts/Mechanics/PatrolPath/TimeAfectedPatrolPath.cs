﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class TimeAfectedPatrolPath : PatrolPath
    {
        private float timeScale;

        public TimeAfectedPatrolPath(List<Vector2> path, float pathDuration) : base(path, pathDuration)
        {
        }

        public void ScaleTime(float timeScale)
        {
            this.timeScale = timeScale;
            AssignSectionsDuration(pathDuration * timeScale);
        }

        public void UnScaleTime()
        {
            AssignSectionsDuration(pathDuration);
        }
    }
}
