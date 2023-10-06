using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatWalk
{
    public class CatWalkPoint : MonoBehaviour
    {
        private Transform _transform;
        public Vector3 Position { get { return _transform.position; }}

        private void Start()
        {
            _transform = gameObject.transform;
        }
    }
}