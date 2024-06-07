using System;
using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;

public class HealthPlayer : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator _Animator;
    [SerializeField] private float _MaxHealth;

    [SerializeField] private int _CountKeyDown;
    [SerializeField] private KeyCode _HotKey; 

    public float Health { get; private set; }

    public static event Action OnStun;
    public static event Action OnRevival;

    private bool _InStun;

    private void Start()
    {
        Health = _MaxHealth;
    }

    public bool TryApplyDamage(float damage = 1)
    {
        if(damage < 0 || _InStun)
            return false;
        Health -= damage;
        if(Health <= 0)
        {
            Health = 0;
            _InStun = true;
            _Animator.SetBool("IsDie", _InStun);
            StartCoroutine(Revivaled());
            OnStun?.Invoke();
        }
        return true;
    }


    private IEnumerator Revivaled()
    {
        int countKeyDown = 0;
        while(countKeyDown < _CountKeyDown)
        {
            if(Input.GetKeyDown(_HotKey))
            {
                countKeyDown++;
                Debug.Log(countKeyDown);
            }
            yield return null;
        }
        _InStun = false;
        _Animator.SetBool("IsDie", _InStun);
        OnRevival?.Invoke();
    }
}