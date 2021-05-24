namespace Platformer.Mechanics.Player.PlayerStates
{
    /// <summary>
    /// interface from which states that the Player can be will inherit
    /// </summary>
    public interface PlayerState
    {
        void EnterPlayerState();

        void UpdateState();

        void FixedUpdateState();

        void ExitPlayerState();
    }
}
