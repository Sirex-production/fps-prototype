using Ingame.Ai.Sys;
using Ingame.Animation.Sys;

namespace Ingame.Ai
{
    public sealed class AiFeature : Feature
    {
        public AiFeature(GameplayContext contexts)
        {
            Add(new RunStateMachineSys(contexts));
            Add(new FloatFlyingAiSys());
            Add(new SynchronizeAiAnimationWithNavMeshSys());
        }
    }
}