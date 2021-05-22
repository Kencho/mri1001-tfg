using Platformer.Core;
using Platformer.Mechanics.Player;
using Platformer.Mechanics.Player.PlayerStates;
using Platformer.Model;

namespace Platformer.Gameplay.PlayerEvents
{
    /// <summary>
    /// Event that disables the simulating of the physics and the capture of the controller inputs
    /// </summary>
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

