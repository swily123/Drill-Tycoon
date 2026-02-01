using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] private float _damage;

    public void OnContact(Block block)
    {
        block.TakeDamage(_damage);

        if (block != null) //TODO AddForce, откинуть назад если не смог сломать
        {
            Debug.Log("Block Hit");
        }
        else
        {
            Debug.Log("Block die");
        }
    }
}