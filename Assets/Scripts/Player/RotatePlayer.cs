using System.Collections;
using UnityEngine;


public class RotatePlayer : TransformUser
{
    private Camera _Camera;
    private Plane _Plane;

    private void Start()
    {
        _Camera = Camera.main;
        _Plane = new Plane(Vector3.up, Transform.position);
    }

    private void Update()
    {
        Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
        if (_Plane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance) - Transform.position;

            Transform.rotation = Quaternion.LookRotation(point);
        }
    }
}