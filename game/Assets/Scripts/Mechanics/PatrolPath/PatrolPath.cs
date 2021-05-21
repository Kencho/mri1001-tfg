using Platformer.Resources;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics.PatrolPath
{
    public partial class PatrolPath
    {
        private List<Vector2> path;
        private List<float> sectionsDuration; //in seconds
        protected float pathDuration;
        private int currentPathSection;
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