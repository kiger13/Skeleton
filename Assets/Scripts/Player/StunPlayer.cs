using System.Collections;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] _PlayerComponents;

    private void OnEnable()
    {
        HealthPlayer.OnStun += Stuning;
        HealthPlayer.OnRevival += Unstuning;
    }

    private void OnDisable()
    {
        HealthPlayer.OnStun -= Stuning;
        HealthPlayer.OnRevival -= Unstuning;
    }

    public void Stuning()
    {
        foreach(var component in _PlayerComponents)
        {
            component.enabled = false;
        }
    }

    public void Unstuning()
    {
        foreach (var component in _PlayerComponents)
        {
            component.enabled = true;
        }
    }
}
