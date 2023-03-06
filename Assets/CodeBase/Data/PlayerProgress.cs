using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData worldData;
        public State heroState;
        public Stats heroStats;

        public PlayerProgress(string initialLevel)
        {
            worldData = new WorldData(initialLevel);
            heroState = new State();
            heroStats = new Stats();
        }
    }
}