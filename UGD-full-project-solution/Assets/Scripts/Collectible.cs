using UnityEngine;

public sealed class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        FindFirstObjectByType<GameManager>()?.CollectCoin();
        gameObject.SetActive(false);
    }
}
