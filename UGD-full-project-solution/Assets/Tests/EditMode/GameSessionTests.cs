using Course.UnityGameDevelopment;
using NUnit.Framework;

public sealed class GameSessionTests
{
    [Test]
    public void CollectingRequiredCoinsWins()
    {
        var session = new GameSession(2);

        session.Start();
        session.CollectCoin();
        session.CollectCoin();

        Assert.That(session.Score, Is.EqualTo(2));
        Assert.That(session.State, Is.EqualTo(SessionState.Won));
    }

    [Test]
    public void HazardFailsOnlyActiveGame()
    {
        var session = new GameSession();

        session.HitHazard();
        Assert.That(session.State, Is.EqualTo(SessionState.Ready));

        session.Start();
        session.HitHazard();
        Assert.That(session.State, Is.EqualTo(SessionState.Failed));
    }
}
