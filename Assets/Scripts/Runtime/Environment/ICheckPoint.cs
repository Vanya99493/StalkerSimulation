using UnityEngine;

namespace StalkerSimulation.Environment
{
    public interface ICheckPoint
    {
        public Transform CenterTransform { get; }
        public Vector3 SpawnPosition { get; }
        public float CheckPointInnerRadius { get; }
        public float CheckPointOuterRadius { get; }

        public Vector3 GetHoldPosition();
    }
}