using Platformer.Core;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Model;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Enables the simulating of the physics and the capture of the controller´s input
    /// </summary>
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {

        public override void Execute()
        {
            PlayerController player = PlatformerModel.player;
            player.simulatingPhysics = true;
            player.controlEnabled = true;
            player.ChangeState(new PlayerIdleState(player));
        }
    }
}