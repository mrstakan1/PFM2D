using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private AudioClip _coinPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            AudioSource.PlayClipAtPoint(_coinPickupSFX, Camera.main.transform.position);

            Destroy(gameObject);
        }
    }
}