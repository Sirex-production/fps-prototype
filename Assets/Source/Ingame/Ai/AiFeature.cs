using Ingame.Ai.Sys;

namespace Ingame.Ai
{
    public sealed class AiFeature : Feature
    {
        public AiFeature(GameplayContext contexts)
        {
            Add(new RunStateMachine(contexts));
        }
    }
}