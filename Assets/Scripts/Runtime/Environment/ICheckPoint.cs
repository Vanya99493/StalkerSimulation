using UnityEngine;

namespace StalkerSimulation.Environment
{
    public interface ICheckPoint
    {
        public Transform CenterTransform { get; }
        public float CheckPointAreaRadius { get; }
    }
}