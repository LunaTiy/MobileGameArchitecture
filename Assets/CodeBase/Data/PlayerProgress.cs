using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData worldData;
        public State heroState;

        public PlayerProgress(string initialLevel)
        {
            worldData = new WorldData(initialLevel);
            heroState = new State();
        }
    }
}