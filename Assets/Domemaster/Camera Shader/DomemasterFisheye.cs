using System;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[RequireComponent (typeof(Camera))]
public class DomemasterFisheye : PostEffectsBase {

    public Shader fishEyeShader = null;
    private Material fisheyeMaterial = null;

    public override bool CheckResources() {
        CheckSupport (false);
        fisheyeMaterial = CheckShaderAndCreateMaterial(fishEyeShader,fisheyeMaterial);

        if (!isSupported)
            ReportAutoDisable ();
        return isSupported;
    }

    void OnRenderImage (RenderTexture source, RenderTexture destination) {
		if (CheckResources()==false) {
			Graphics.Blit (source, destination);
			return;
		}
		Graphics.Blit (source, destination, fisheyeMaterial);
    }
}
