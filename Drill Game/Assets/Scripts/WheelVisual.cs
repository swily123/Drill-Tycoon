using Player;
using UnityEngine;

public class WheelVisual : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform[] _leftSideWheels;
    [SerializeField] private Transform[] _rightSideWheels;
    [SerializeField] private float _rotationSpeedMultiplier = 10f;

    private void OnEnable()
    {
        _playerMovement.Moving += RotateWheels;
    }

    private void OnDisable()
    {
        _playerMovement.Moving -= RotateWheels;
    }

    private void RotateWheels()
    {
        float speed = _playerMovement.CurrentSpeed;
        float rotationAngle = speed * _rotationSpeedMultiplier * Time.deltaTime;

        foreach (Transform wheel in _rightSideWheels)
        {
            wheel.Rotate(Vector3.forward, rotationAngle, Space.Self);
        }
        
        foreach (Transform wheel in _leftSideWheels)
        {
            wheel.Rotate(Vector3.back, rotationAngle, Space.Self);
        }
    }
}