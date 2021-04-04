using Platformer.Resources;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public partial class PatrolPath
    {
        private List<Vector2> path;
        private List<float> sectionsDuration; //in seconds
        private int currentPathSection;
        private Vector2 currentPosition;

        public List<float> SectionsDuration { get => sectionsDuration;}
        public Vector2 CurrentPosition { get => currentPosition;}

        public PatrolPath(List<Vector2> path, float pathDuration)
        {
            this.path = path;
            AssignSectionsDuration(pathDuration);
            currentPathSection = 0;
            currentPosition = path[0];
        }

        private void AssignSectionsDuration(float pathDuration)
        {
            float totalDistance = 0;
            float[] distances = new float[path.Count];
            sectionsDuration = new List<float>();

            for (int i = 0; i < path.Count; i++){
                distances[i] = MathOperations.getEuclideanDistance(path[i], path[(i + 1) % path.Count]);
                totalDistance += distances[i];
            }
            foreach (float distance in distances)
            {
                sectionsDuration.Add((distance/totalDistance)*pathDuration);
            }
        }

        public Vector2 getNextPathPosition()
        {
            int nextPathSection = (currentPathSection + 1) % path.Count;
            Vector2 distanceMoved = CalculateDistanceMovedThisFrame(nextPathSection);
            Vector2 nextPosition = currentPosition + distanceMoved;
            currentPosition = nextPosition;
            if (isSectiontraveled(nextPathSection))
            {
                currentPathSection = (currentPathSection + 1) % path.Count;
            }
            return currentPosition;
        }

        private Vector2 CalculateDistanceMovedThisFrame(int nextPathSection)
        {
            Vector2 currentSection = path[currentPathSection];
            Vector2 nextSection = path[nextPathSection];

            return ((nextSection - currentSection) * Time.deltaTime) / sectionsDuration[currentPathSection];
        }

        private bool isSectiontraveled(int nextSection)
        {
            if (Mathf.Abs(MathOperations.getEuclideanDistance(path[currentPathSection], currentPosition)) >= Mathf.Abs(MathOperations.getEuclideanDistance(path[currentPathSection], path[nextSection])))
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