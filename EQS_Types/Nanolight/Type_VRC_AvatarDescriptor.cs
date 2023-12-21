#if UNITY_EDITOR && VRC_SDK_VRCSDK3 && !UDON
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using EasyQuestSwitch.Fields;

namespace EasyQuestSwitch.Types
{
    [AddComponentMenu("")]
    public class Type_VRC_AvatarDescriptor : Type_Base
    {
        [System.NonSerialized]
        private VRCAvatarDescriptor type;
        public SharedRuntimeAnimatorController BaseLayer = new SharedRuntimeAnimatorController();
        public SharedRuntimeAnimatorController AdditiveLayer = new SharedRuntimeAnimatorController();
        public SharedRuntimeAnimatorController GestureLayer = new SharedRuntimeAnimatorController();
        public SharedRuntimeAnimatorController ActionLayer = new SharedRuntimeAnimatorController();
        public SharedRuntimeAnimatorController FXLayer = new SharedRuntimeAnimatorController();
        public SharedExpressionsMenu ExpressionsMenu = new SharedExpressionsMenu();
        public SharedExpressionParameters ExpressionsParameters = new SharedExpressionParameters();

        public override void Setup(Object type)
        {
            VRCAvatarDescriptor component = (VRCAvatarDescriptor)type;
            BaseLayer.Setup(component.baseAnimationLayers[0].animatorController);
            AdditiveLayer.Setup(component.baseAnimationLayers[1].animatorController);
            GestureLayer.Setup(component.baseAnimationLayers[2].animatorController);
            ActionLayer.Setup(component.baseAnimationLayers[3].animatorController);
            FXLayer.Setup(component.baseAnimationLayers[4].animatorController);
            ExpressionsMenu.Setup(component.expressionsMenu);
            ExpressionsParameters.Setup(component.expressionParameters);
        }

        public override void Process(Object type, BuildTarget buildTarget)
        {
            VRCAvatarDescriptor component = (VRCAvatarDescriptor)type;
            component.baseAnimationLayers[0].animatorController = BaseLayer.Get(buildTarget);
            component.baseAnimationLayers[1].animatorController = AdditiveLayer.Get(buildTarget);
            component.baseAnimationLayers[2].animatorController = GestureLayer.Get(buildTarget);
            component.baseAnimationLayers[3].animatorController = ActionLayer.Get(buildTarget);
            component.baseAnimationLayers[4].animatorController = FXLayer.Get(buildTarget);
            component.expressionsMenu = ExpressionsMenu.Get(buildTarget);
            component.expressionParameters = ExpressionsParameters.Get(buildTarget);
        }
    }
}
#endif