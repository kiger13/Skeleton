using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : TransformUser
{
    [SerializeField] private float _MaxDistance;
    [SerializeField] private float _Delay;
    [SerializeField] private float _Time;
    [SerializeField] private ExampleGameDifficult _Example;
    [SerializeField] private TargetEnemy _Target;
    private Wave _Wave;

    public void StartSpawner(Wave wave)
    {
        _Wave = wave;
        StartCoroutine(Spawned());
    }

    private IEnumerator Spawned()
    {
        var gameDifficult = _Example.GameDifficulty;
        int countEnemy = 0;
        while (gameDifficult.CountEnemy > countEnemy)
        {
            var random = Random.Range(0, gameDifficult.CountTypeEnemyInWave - 1);
            var randomEnemy = _Wave._Enemies[random];
            var instanceEnemy = Instantiate(randomEnemy, Transform.position, Transform.rotation);
            if(instanceEnemy.TryGetComponent(out MovementEnemy enemy))
            {
                enemy.Initialized(_Target.TargetEnd);
            }    
            countEnemy++;
            yield return new WaitUntil(() => EnemyFarAway(Transform.position, instanceEnemy.transform.position));
        }
        gameDifficult.TryApplyDifficulty(_Time);
    }

    private bool EnemyFarAway(Vector3 position, Vector3 enemyPosition)
    {
        var distance = Vector3.Distance(position, enemyPosition);
        return distance >= _MaxDistance;
    }
}