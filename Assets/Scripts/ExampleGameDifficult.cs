using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class ExampleGameDifficult : MonoBehaviour
{
    [SerializeField] private AnimationCurve _Difficult;

    [SerializeField] private int _MaxCountEnemy ;
    [SerializeField] private int _MaxCountTypeInWave;
    [SerializeField] private int _MaxStrenghtEnemy;

    public GameDifficulty GameDifficulty { get; private set; }

    public void Awake()
    {
        GameDifficulty = new GameDifficulty
        (
            _MaxCountEnemy,
            _MaxCountTypeInWave,
            _MaxStrenghtEnemy,
            _Difficult
        );
        GameDifficulty.TryApplyDifficulty(0);
    }
}
