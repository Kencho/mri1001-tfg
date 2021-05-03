using Platformer.Core;
using Platformer.Model;
using Platformer.Player;

namespace Platformer.Gameplay
{
    /// <summary>
    /// This event is fired when user input should be enabled.
    /// </summary>
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            PlayerController player = model.player;
            player.simulatingPhysics = true;
            player.controlEnabled = true;
            player.playerState = new PlayerIdleState(player);
        }
    }
}