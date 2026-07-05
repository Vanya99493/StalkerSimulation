using System.Collections.Generic;
using UnityEngine;

namespace StalkerSimulation.Environment
{
    public class CheckPoint : MonoBehaviour, ICheckPoint
    {
        [SerializeField]
        private List<Transform> _obstacles = new();
        
        [Space(10)]
        [SerializeField]
        private Transform _spawnPoint;
        
        [Space(10)]
        [SerializeField]
        private float _innerRadius = 5f;
        
        [SerializeField]
        private float _outerRadius = 10f;
        
        public Transform CenterTransform => transform;
        public Vector3 SpawnPosition => _spawnPoint != null ? _spawnPoint.position : CenterTransform.position;
        public float CheckPointInnerRadius => _innerRadius;
        public float CheckPointOuterRadius => _outerRadius;

        public Vector3 GetHoldPosition()
        {
            return CenterTransform.position;
        }
    }
}