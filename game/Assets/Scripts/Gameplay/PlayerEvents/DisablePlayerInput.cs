using Platformer.Core;
using Platformer.Model;
using Platformer.Player;

public class DisablePlayerInput : Simulation.Event<DisablePlayerInput>
{
    public override void Execute()
    {
        PlayerController player = PlatformerModel.player;
        player.simulatingPhysics = false;
        player.controlEnabled = false;
        player.playerState = new PlayerIdleState(player);
    }
}
