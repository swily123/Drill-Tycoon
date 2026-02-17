using UnityEngine;

namespace Player
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        
        public Transform GetSpawnPoint()
        {
            if (_spawnPoints.Length > 0)
            {
                return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            }
            else
            {
                throw new System.Exception("No spawn points available");
            }
        }
    }
}