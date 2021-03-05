using Platformer.Core;
using Platformer.Model;
using Platformer.Prueba;

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
            var player = model.player;
            player.playerState = new PlayerIdleState(player);
            //player.controlEnabled = true;
        }
    }
}