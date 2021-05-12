using Platformer.Core;
using Platformer.Model;
using Platformer.Player;

namespace Platformer.Gameplay
{
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {

        public override void Execute()
        {
            PlayerController player = PlatformerModel.player;
            player.simulatingPhysics = true;
            player.controlEnabled = true;
            player.playerState = new PlayerIdleState(player);
        }
    }
}