using UnityEngine;

public class Item : MonoBehaviour
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}