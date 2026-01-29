using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericsExample : MonoBehaviour
{
    [SerializeField] private Apple[] _apples;
    [SerializeField] private Banana[] _banana;

    private Storage<Apple> _appleStorage;
    private Storage<Banana> _bananaStorage;

    private void Awake()
    {
        _appleStorage = new Storage<Apple>();
        _bananaStorage = new Storage<Banana>();

        foreach (Apple apple in _apples)
        {
            _appleStorage.Add(apple);
        }

        foreach (Banana banana in _banana)
        {
            _bananaStorage.Add(banana);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Apple apple = _appleStorage.GetRandom();
            _appleStorage.Remove(apple);
            apple.ChangeScaleTo(new Vector3(2, 2, 2));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Banana banana = _bananaStorage.GetRandom();
            _bananaStorage.Remove(banana);
            banana.Eat();
        }
    }
}
