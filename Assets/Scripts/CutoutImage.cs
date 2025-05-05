
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
public class CutoutImage : Image
{
    public override Material materialForRendering
    {
        get {
            Material mat = new Material(base.materialForRendering);
            material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            return mat;
        
        }

    }
}
