using Entitas;
using Ingame.Interactive.Environment.Sys;

namespace Ingame.Interactive.Environment
{
    public sealed class EnvironmentFeature : Feature
    {
        public EnvironmentFeature(GameplayContext contexts)
        {
            Add(new LeakPipeGasSys(contexts));
        }
 
    }
}