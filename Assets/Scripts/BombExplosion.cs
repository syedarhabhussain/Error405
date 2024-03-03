using Unity.VisualScripting;
using UnityEngine;

public class DestoryItself : MonoBehaviour
{
    public float destroyDelay = 3f;

    void Start()
    {
        Invoke("DestroyProjectile", destroyDelay);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
