#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using EasyQuestSwitch.Fields;

namespace EasyQuestSwitch.Types
{
    [AddComponentMenu("")]
    public class Type_ParticleSystem : Type_Base
    {
        [System.NonSerialized]
        private ParticleSystem type;
        public SharedMaterial RendererMaterial = new SharedMaterial();
        public SharedMaterial RendererTrailMaterial = new SharedMaterial();

        public override void Setup(Object type)
        {
            ParticleSystem component = (ParticleSystem)type;
            ParticleSystemRenderer renderer = component.GetComponent<ParticleSystemRenderer>();
            RendererMaterial.Setup(renderer.sharedMaterial);
            RendererTrailMaterial.Setup(renderer.trailMaterial);
        }

        public override void Process(Object type, BuildTarget buildTarget)
        {
            ParticleSystem component = (ParticleSystem)type;
            ParticleSystemRenderer renderer = component.GetComponent<ParticleSystemRenderer>();
            renderer.sharedMaterial = RendererMaterial.Get(buildTarget);
            renderer.trailMaterial = RendererTrailMaterial.Get(buildTarget);
        }
    }
}
#endif