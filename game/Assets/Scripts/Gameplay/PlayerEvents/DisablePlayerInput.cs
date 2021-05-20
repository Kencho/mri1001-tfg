using Platformer.Core;
using Platformer.Model;
using Platformer.Player;

namespace Platformer.Gameplay
{
    public class DisablePlayerInput : Simulation.Event<DisablePlayerInput>
    {
        public override void Execute()
        {
            PlayerController player = PlatformerModel.player;
            player.simulatingPhysics = false;
            player.controlEnabled = false;
            player.ChangeState(new PlayerIdleState(player));
        }
    }
}

