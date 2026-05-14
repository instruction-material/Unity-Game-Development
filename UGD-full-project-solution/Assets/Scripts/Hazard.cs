using UnityEngine;

public sealed class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            FindFirstObjectByType<GameManager>()?.FailRun();
    }
}
