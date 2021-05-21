namespace Platformer.Mechanics.Player.PlayerStates
{
    public interface PlayerState
    {
        void EnterPlayerState();

        void UpdateState();

        void FixedUpdateState();

        void ExitPlayerState();
    }
}
