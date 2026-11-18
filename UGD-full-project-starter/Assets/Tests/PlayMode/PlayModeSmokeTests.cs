using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class PlayModeSmokeTests
{
    [Test]
    public void ProjectCanCreateCoreRuntimeObjects()
    {
        var manager = new GameObject("GameManager").AddComponent<GameManager>();

        manager.StartGame();

        Assert.That(manager.State.ToString(), Is.EqualTo("Playing"));
        Object.DestroyImmediate(manager.gameObject);
    }

    [Test]
    public void PickupWaitsForStartAndCountsOnlyOnce()
    {
        var manager = new GameObject("GameManager").AddComponent<GameManager>();
        var player = new GameObject("Player");
        player.tag = "Player";
        var playerCollider = player.AddComponent<BoxCollider2D>();
        var coin = new GameObject("Coin");
        coin.AddComponent<Collectible>();

        try
        {
            coin.SendMessage("OnTriggerEnter2D", playerCollider);
            Assert.That(coin.activeSelf, Is.True);
            Assert.That(manager.Score, Is.EqualTo(0));

            manager.StartGame();
            coin.SendMessage("OnTriggerEnter2D", playerCollider);
            Assert.That(coin.activeSelf, Is.False);
            Assert.That(manager.Score, Is.EqualTo(1));

            coin.SendMessage("OnTriggerEnter2D", playerCollider);
            Assert.That(manager.Score, Is.EqualTo(1));
        }
        finally
        {
            Object.DestroyImmediate(coin);
            Object.DestroyImmediate(player);
            Object.DestroyImmediate(manager.gameObject);
        }
    }
}
