using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial.UniversalStorage
{
    public class StatsExample : MonoBehaviour
    {
        private Stats _stats;

        private void Awake()
        {
            _stats = new Stats();

            _stats.Add(StatTypes.Health, new ReactiveVariable<float>(10f));
            _stats.Add(StatTypes.Attack, new ReactiveVariable<float>(5));
            _stats.Add(StatTypes.RadiusInCells, new ReactiveVariable<int>(6));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (_stats.TryGet(StatTypes.Health, out ReactiveVariable<float> healthStat))
                {
                    healthStat.Value -= 1f;
                    Debug.Log($"Health decreased: {healthStat.Value}");
                }
                else
                {
                    Debug.Log("Health stat not found");
                }
            }
        }
    }
} 

