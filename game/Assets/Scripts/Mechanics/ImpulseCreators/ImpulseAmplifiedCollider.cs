namespace Platformer.Mechanics.ImpulseCreators
{
    /// <summary>
    /// ImpulseCreatorCollider with a ImpulseCreator of the type ImpulseAmplifier
    /// </summary>
    public class ImpulseAmplifiedCollider : ImpulseCreatorCollider
    {
        public float velocityScale;

        protected override void SetImpulseCreator()
        {
            impulseCreator = new ImpulseAmplifier(velocityScale);
        }
    }
}

