namespace Platformer.Mechanics.Player.PlayerMechanics
{
    public interface PlayerMechanic
    {
        void ManageInput();
        void ManageFlags();
        void ExecuteMechanic();
    }
}

