using UnityEngine;

namespace StalkerSimulation.Environment
{
    public class CheckPoint : MonoBehaviour, ICheckPoint
    {
        [SerializeField]
        private float _areaRadius = 10f;
        
        public Transform CenterTransform => transform;
        public float CheckPointAreaRadius => _areaRadius;
    }
}