using UnityEngine;

namespace ItemSystem
{
    public class ItemVisuals
    {
        private Renderer _renderer;

        public void SetRenderer(Renderer renderer)
        {
            if (renderer == null)
                return;
            
            _renderer = renderer;
        }
        
        public void SetMaterial(Material material)
        {
            if (material == null || _renderer == null)
                return;
            
            _renderer.material = material;
        }
    }
}