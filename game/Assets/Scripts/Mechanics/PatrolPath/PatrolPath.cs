using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.PatrolPath
{
    /// <summary>
    /// Class that calculates the position of a object that follows a path in a instance of time
    /// </summary>
    public partial class PatrolPath
    {
        /// <summary>
        /// List of points the object is going to go to
        /// </summary>
        private List<Vector2> path;
        /// <summary>
        /// List of the seconds that is goint to take move between points
        /// </summary>
        private List<float> sectionsDuration;
        /// <summary>
        /// Total time in seconds that takes travel all the path
        /// </summary>
        protected float pathDuration;
        private int currentPathSection;
        /// <summary>
        /// Actual position of the object
        /// </summary>
        private Vector2 currentPosition;

        public List<float> SectionsDuration { get => sectionsDuration;}
        public Vector2 CurrentPosition { get => currentPosition;}

        public PatrolPath(List<Vector2> path, float pathDuration)
        {
            this.path = path;
            this.pathDuration = pathDuration;
            AssignSectionsDuration(pathDuration);
            currentPathSection = 0;
            currentPosition = path[0];
        }

        /// <summary>
        /// Calculates the time that will take travel each section 
        /// </summary>
        /// <param name="pathDuration"></param>
        protected void AssignSectionsDuration(float pathDuration)
        {
            float totalDistance = 0;
            float[] distances = new float[path.Count];
            sectionsDuration = new List<float>();

            for (int i = 0; i < path.Count; i++){
                Vector2 posCurrentSection = path[i];
                Vector2 posNextSection = path[(i + 1) % path.Count];
                distances[i] = (posNextSection - posCurrentSection).magnitude;
                totalDistance += distances[i];
            }
            foreach (float distance in distances)
            {
                sectionsDuration.Add((distance/totalDistance)*pathDuration);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>next position of the object</returns>
        public Vector2 GetNextPathPosition()
        {
            int nextPathSection = (currentPathSection + 1) % path.Count;
            Vector2 distanceMoved = CalculateDistanceMovedThisFrame(nextPathSection);
            Vector2 nextPosition = currentPosition + distanceMoved;
            currentPosition = nextPosition;
            if (IsSectionTraveled(nextPathSection))
            {
                currentPathSection = (currentPathSection + 1) % path.Count;
            }
            return currentPosition;
        }

        private Vector2 CalculateDistanceMovedThisFrame(int nextPathSection)
        {
            Vector2 currentSection = path[currentPathSection];
            Vector2 nextSection = path[nextPathSection];

            return ((nextSection - currentSection) * Time.deltaTime)/ sectionsDuration[currentPathSection];
            
        }

        private bool IsSectionTraveled(int nextSection)
        {
            if (Mathf.Abs((currentPosition - path[currentPathSection]).magnitude) >= Mathf.Abs((path[nextSection] - path[currentPathSection]).magnitude))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}