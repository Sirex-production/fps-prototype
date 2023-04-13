using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Ingame.Interactive.Environment.Cmp
{
    [Gameplay, FlagPrefix("has"), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class PerformInteractionTag : IComponent
    {
        
    }
}