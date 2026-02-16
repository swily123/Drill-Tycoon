using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action<Vector3> Moving;

    private void Update()
    {
        Vector3 movement = Vector3.left * Input.GetAxisRaw("Horizontal") + Vector3.back * Input.GetAxisRaw("Vertical");

        movement.Normalize();
        Moving?.Invoke(movement);
    }
}