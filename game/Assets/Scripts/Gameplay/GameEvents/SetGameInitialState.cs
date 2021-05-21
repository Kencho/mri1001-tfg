using Platformer.Core;
using Platformer.Model;

namespace Platformer.Gameplay.GameEvents
{
    public class SetGameInitialState : Simulation.Event<SetGameInitialState>
    {

        public override void Execute()
        {
            PlatformerModel.gameController.SetStartingState(3.5f);
        }
    }
}

