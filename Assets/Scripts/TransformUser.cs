using UnityEngine;

public class TransformUser : MonoBehaviour
{
    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = GetComponent<Transform>();
    }
}
