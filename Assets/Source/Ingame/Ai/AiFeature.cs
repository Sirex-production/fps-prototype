using Ingame.Ai.Sys;

namespace Ingame.Ai
{
    public sealed class AiFeature : Feature
    {
        public AiFeature()
        {
            Add(new RunStateMachine());
        }
    }
}