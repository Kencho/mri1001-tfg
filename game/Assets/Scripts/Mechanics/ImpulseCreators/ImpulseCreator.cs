using Platformer.Mechanics.KinematicObjects;

namespace Platformer.Mechanics.ImpulseCreators
{
    /// <summary>
    /// Interface from which classes that impulses KinematicObjects will inherit
    /// </summary>
    public interface ImpulseCreator
    {

        void ImpulseKinematicObject(KinematicObject kineObj);
    }
}

