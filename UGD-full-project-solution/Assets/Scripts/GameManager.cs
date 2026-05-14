using Course.UnityGameDevelopment;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private readonly GameSession session = new();

    public int Score => session.Score;
    public SessionState State => session.State;

    public void StartGame() => session.Start();
    public void CollectCoin() => session.CollectCoin();
    public void FailRun() => session.HitHazard();
    public void ResetRun() => session.Reset();
}
