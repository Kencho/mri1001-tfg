using Platformer.Core;
using Platformer.Model;

namespace Platformer.Gameplay.GameEvents
{
    public class SetGameInitialState : Simulation.Event<SetGameInitialState>
    {
        private const float WAIT_TIME_UNITL_EXECUTE = 3.5f;

        public override void Execute()
        {
            PlatformerModel.gameController.SetStartingState(WAIT_TIME_UNITL_EXECUTE);
        }
    }
}

