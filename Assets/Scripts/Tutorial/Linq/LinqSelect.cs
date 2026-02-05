using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Tutorial.Linq
{
    public class LinqSelect : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        private void Awake()
        {
            List<Vector3> positions = new List<Vector3>();

            for (int i = 0; i < _points.Count; i++)
                positions.Add(_points[i].position);

            positions = _points.Select(point => point.position).ToList();
        }
    }
}


