using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreatorWave : MonoBehaviour
{
    [SerializeField] private StrenghtEnemy[] _Enemies;
    [SerializeField] private ExampleGameDifficult _Example;
    [SerializeField] private Spawner _Spawner;

    private Wave _Wave;
    private CounterWaves _Counter;

    private void Start()
    {
        _Counter = new CounterWaves();
    }

    public void StartWave()
    {
        List<StrenghtEnemy> enemies = new();
        foreach(var strenght in _Enemies)
        {
            if(strenght.Value <= _Example.GameDifficulty.StrenghtEnemy)
            {
                enemies.Add(strenght);
            }
        }

        _Wave = new Wave(enemies.ToArray());
        _Counter.AddWaveCount();
        _Spawner.StartSpawner(_Wave);
    }
}
