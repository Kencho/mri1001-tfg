﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class ImpulseAmplifiedCollider : ImpulseCreatorCollider
    {
        public float velocityScale;

        protected override void SetImpulseCreator()
        {
            impulseCreator = new ImpulseAmplifier(velocityScale);
        }
    }
}
