using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.PatrolPath
{
    /// <summary>
    /// PatrolPath that variates the time that takes to travel the path based on a time scale
    /// </summary>
    public class TimeAffectedPatrolPath : PatrolPath
    {
        private float timeScale;

        public TimeAffectedPatrolPath(List<Vector2> path, float pathDuration) : base(path, pathDuration)
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

