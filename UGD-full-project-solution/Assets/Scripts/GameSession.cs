using System;

namespace Course.UnityGameDevelopment
{
    public enum SessionState
    {
        Ready,
        Playing,
        Won,
        Failed
    }

    public sealed class GameSession
    {
        public int RequiredCoins { get; }
        public int Score { get; private set; }
        public SessionState State { get; private set; }

        public GameSession(int requiredCoins = 5)
        {
            if (requiredCoins <= 0)
                throw new ArgumentOutOfRangeException(nameof(requiredCoins), "Required coins must be positive.");

            RequiredCoins = requiredCoins;
            State = SessionState.Ready;
        }

        public void Start()
        {
            if (State == SessionState.Ready)
                State = SessionState.Playing;
        }

        public void CollectCoin()
        {
            if (State != SessionState.Playing)
                return;

            Score++;
            if (Score >= RequiredCoins)
                State = SessionState.Won;
        }

        public void HitHazard()
        {
            if (State == SessionState.Playing)
                State = SessionState.Failed;
        }

        public void Reset()
        {
            Score = 0;
            State = SessionState.Ready;
        }
    }
}
