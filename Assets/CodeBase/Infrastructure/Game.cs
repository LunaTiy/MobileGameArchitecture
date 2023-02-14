using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            RegisterInputService();
        }

        private static void RegisterInputService()
        {
            InputService = Application.isEditor
                ? new StandaloneInputService()
                : new MobileInputService();
        }
    }
}