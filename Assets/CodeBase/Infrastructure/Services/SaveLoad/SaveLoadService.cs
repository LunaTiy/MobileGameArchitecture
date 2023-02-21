using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISavedLoadService
    {
        private const string Progress = "Progress";

        public void SaveProgress()
        {
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(Progress)?.ToDeserialized<PlayerProgress>();
    }
}