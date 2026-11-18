using Course.UnityGameDevelopment;
using UnityEngine;

public sealed class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.activeSelf || !other.CompareTag("Player"))
            return;

        var manager = FindFirstObjectByType<GameManager>();
        if (manager == null || manager.State != SessionState.Playing)
            return;

        manager.CollectCoin();
        gameObject.SetActive(false);
    }
}
