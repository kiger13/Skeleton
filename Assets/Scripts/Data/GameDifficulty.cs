using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameDifficulty
{
    [SerializeField] private int _MaxCountEnemy;
    [SerializeField] private int _MaxCountTypeEnemyInWave;
    [SerializeField] private int _MaxStrenghtEnemy;
    [SerializeField] private AnimationCurve _Difficulty;

    private float _DifficultyTime = 0;

    private int _CountEnemy;
    private int _StrenghtEnemy;
    private int _CountTypeEnemyInWave;

    public GameDifficulty(int maxCountEnemy, int maxCountTypeEnemyInWave, int maxStrenghtEnemy, AnimationCurve diffuculty)
    {
        _MaxCountEnemy = maxCountEnemy;
        _MaxCountTypeEnemyInWave = maxCountTypeEnemyInWave;
        _MaxStrenghtEnemy = maxStrenghtEnemy;
        _Difficulty = diffuculty;
    }

    public int MaxCountEnemy => _MaxCountEnemy;
    public int MaxCountTypeInWave => _MaxCountTypeEnemyInWave;
    public int MaxStrenghtEnemy => _MaxStrenghtEnemy;

    public int CountEnemy => _CountEnemy;
    public int StrenghtEnemy => _StrenghtEnemy;
    public int CountTypeEnemyInWave => _CountTypeEnemyInWave;

    public void TryApplyDifficulty(float addTime)
    {
        if (addTime < 0)
        {
            return;
        }
        _DifficultyTime += addTime;
        var difficulty = _Difficulty.Evaluate(_DifficultyTime);
        _CountEnemy = (int)(difficulty * _MaxCountEnemy);
        _CountTypeEnemyInWave = (int)(difficulty * _MaxCountTypeEnemyInWave);
    }
}
