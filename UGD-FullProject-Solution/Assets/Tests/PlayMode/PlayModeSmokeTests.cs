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
}
