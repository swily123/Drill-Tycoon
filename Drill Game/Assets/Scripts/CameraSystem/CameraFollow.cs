using System.Collections;
using InventorySystem;
using Unity.Cinemachine;
using UnityEngine;

namespace CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private CinemachineFollow _cinemachineFollow;
        [SerializeField] private CameraConfig _cameraConfig;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Zone _zone;
        [SerializeField] private float _smoothness;
        [SerializeField] private Vector3 _zoneOffset;

        private const float SmoothnessThreshold = 0.005f;

        private bool _isInZone;
        private Vector3 _currentOffset;
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _inventory.OnMaxCountChanged += ChangeOffset;
            _zone.ZoneEntered += ChangeOffsetInZone;
        }

        private void OnDisable()
        {
            _inventory.OnMaxCountChanged -= ChangeOffset;
            _zone.ZoneEntered -= ChangeOffsetInZone;
        }

        private void ChangeOffsetInZone(bool isInZone)
        {
            CarefullyStopCoroutine();

            _coroutine = StartCoroutine(isInZone ? SmoothChangingOffset(_currentOffset + _zoneOffset) : SmoothChangingOffset(_currentOffset));
            _isInZone = isInZone;
        }

        private IEnumerator SmoothChangingOffset(Vector3 targetOffset)
        {
            while ((_cinemachineFollow.FollowOffset - targetOffset).sqrMagnitude > SmoothnessThreshold)
            {
                _cinemachineFollow.FollowOffset = Vector3.Lerp(_cinemachineFollow.FollowOffset, targetOffset, Time.deltaTime * _smoothness);
                yield return null;
            }

            _cinemachineFollow.FollowOffset = targetOffset;
        }

        private void ChangeOffset(int count)
        {
            _currentOffset = _cameraConfig.GetOffset(count);
            ChangeOffsetInZone(_isInZone);
        }

        private void CarefullyStopCoroutine()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
    }
}