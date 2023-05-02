using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Source.EcsSupport.Support
{
    public sealed class UnlinkEntityFromGameObjectSys : ITearDownSystem 
    {
        public void TearDown()
        {
            /*var links = Contexts.sharedInstance.gameplay.GetGroup(GameplayMatcher.ClearLinkOnDestroyMdl);
            foreach (var link in links)
            {
                
                 
            }*/
        }
    }
} 