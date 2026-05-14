using Course.UnityGameDevelopment;
using NUnit.Framework;

public sealed class GameSessionTests
{
    [Test]
    public void NewSessionStartsReady()
    {
        var session = new GameSession();

        Assert.That(session.Score, Is.EqualTo(0));
        Assert.That(session.State, Is.EqualTo(SessionState.Ready));
        Assert.That(session.RequiredCoins, Is.GreaterThan(0));
    }
}
