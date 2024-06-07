using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] private Transform _TargetEnd;

    public Transform TargetEnd => _TargetEnd;
}
