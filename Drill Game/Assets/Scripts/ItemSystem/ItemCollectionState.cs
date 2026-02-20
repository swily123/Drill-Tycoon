using System.Collections;
using UnityEngine;

namespace ItemSystem
{
    public class ItemCollectionState : MonoBehaviour
    {
        [SerializeField] private LayerMask _nonCollectibleMask;
        [SerializeField] private LayerMask _collectibleMask;
        [SerializeField] private float _immuneDelay = 1f;

        private const float MathLayerLog = 2;
        
        public bool CanBeCollected { get; private set; }
        
        private GameObject _gameObject;
        private Coroutine _immuneCoroutine;
        
        public void SetGameObject(GameObject victimGameObject)
        {
            if (victimGameObject == null)
                return;
            
            _gameObject = victimGameObject;
        }
        
        public void SetImmune(bool isImmune = true)
        {
            StopImmuneCoroutine();
            
            if (isImmune)
                _immuneCoroutine = StartCoroutine(ImmuneToCollected());
        }

        public void OnCollect()
        {
            CanBeCollected = false;
        }

        private void StopImmuneCoroutine()
        {
            if (_immuneCoroutine != null)
                StopCoroutine(_immuneCoroutine);
        }
        
        private IEnumerator ImmuneToCollected()
        {
            MakeCollectible(false);
            yield return new WaitForSeconds(_immuneDelay);
            MakeCollectible();
        }
        
        private void MakeCollectible(bool collectible = true)
        {
            if (_gameObject is null)
                return;
            
            if (collectible)
                _gameObject.layer = (int)Mathf.Log(_collectibleMask.value, MathLayerLog);
            else
                _gameObject.layer = (int)Mathf.Log(_nonCollectibleMask.value, MathLayerLog);
            
            CanBeCollected = collectible;
        }
    }
}