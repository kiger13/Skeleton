using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[SelectionBase]
public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _Speed;
    [SerializeField] private Animator _Animator;

    private Rigidbody _RigidBody;

    private Vector3 Direction
    {
        get
        {
            return new Vector3
            (
                Input.GetAxisRaw("Horizontal"),
                0,
                Input.GetAxisRaw("Vertical")
            ).normalized;
        }
    }

    private void Awake()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _Animator.SetBool("Running", Direction != Vector3.zero);
        _RigidBody.MovePosition(_RigidBody.position + Direction * _Speed * Time.fixedDeltaTime);
    }
}