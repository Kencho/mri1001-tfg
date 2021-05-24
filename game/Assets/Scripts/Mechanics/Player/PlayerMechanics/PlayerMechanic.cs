namespace Platformer.Mechanics.Player.PlayerMechanics
{
    /// <summary>
    /// interface from which mechanics moved to a class will inherit
    /// </summary>
    public interface PlayerMechanic
    {
        void ManageInput();
        void ManageFlags();
        void ExecuteMechanic();
    }
}

