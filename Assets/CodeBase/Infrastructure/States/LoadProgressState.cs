using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISavedLoadService _savedLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService,
            ISavedLoadService savedLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _savedLoadService = savedLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();

            _gameStateMachine.Enter<LoadLevelState, string>(_progressService.Progress.worldData.positionOnLevel.level);
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew() =>
            _progressService.Progress = _savedLoadService.LoadProgress() ?? NewProgress();

        private static PlayerProgress NewProgress() =>
            new PlayerProgress(initialLevel: "Main")
                .With(x => x.heroState.maxHp = 50f)
                .With(x => x.heroState.ResetHp())
                .With(x => x.heroStats.damage = 1f)
                .With(x => x.heroStats.attackRadius = 0.5f);
    }
}