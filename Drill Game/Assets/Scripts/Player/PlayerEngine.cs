using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerEngine : MonoBehaviour
    {
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerRotation _playerRotation;
        [SerializeField] private PlayerGravity _playerGravity;
        
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerGravity.Initialize(_rigidbody);
            _playerMovement.Initialize(_rigidbody);
        }

        private void OnEnable()
        {
            _inputReader.Moving += OnMovementInput;
        }

        private void OnDisable()
        {
            _inputReader.Moving -= OnMovementInput;
        }
    
        private void OnMovementInput(Vector3 direction)
        {
            _playerRotation.Rotate(direction);
            _playerMovement.Move(direction);
        }
    }
}