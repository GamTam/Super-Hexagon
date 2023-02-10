using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;

    private float _timer;
    private Random rand = new Random();

    private void Start()
    {
        _timer = rand.Next(3, 4);
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = rand.Next(0, 4);
            int enemy = rand.Next(_enemies.Length);

            Vector2 pos = new Vector2();

            do
            {
                pos = UnityEngine.Random.insideUnitCircle * 8;
            } while (pos.magnitude < 5);

            Instantiate(_enemies[enemy], pos, Quaternion.identity);
        }
    }
}
