Shader "DomemasterFisheyeShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "" {}
	}
	
	CGINCLUDE
	
	#include "UnityCG.cginc"
	
	struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
	};
	
	sampler2D _MainTex;
	
	v2f vert( appdata_img v ) 
	{
		v2f o;
		o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		o.uv = v.texcoord.xy;
		return o;
	} 
	
	half4 frag(v2f i) : SV_Target 
	{
	
	 float aperature = 180.0;				
	 float PI = 3.1415926535;
	 float apertureHalf = 0.5 * aperature * (PI / 180.0);
	  
	  // This factor ajusts the coordinates in the case that
	  // the aperture angle is less than 180 degrees, in which
	  // case the area displayed is not the entire half-sphere.
	  float maxFactor = sin(apertureHalf);
	  
	  half2 pos = 2.0 * i.uv - 1.0;
	  
	  float l = length(pos);
	  if (l > 1.0) {
	    return half4(0, 0, 0, 1);  
	  } else {
	    float x = maxFactor * pos.x;
	    float y = maxFactor * pos.y;
	    float n = length(half2(x, y));
	    float z = sqrt(1.0 - n * n);
	    float r = atan2(n, z) / PI; 
	    float phi = atan2(y, x);
	    float u = r * cos(phi) + 0.5;
	    float v = r * sin(phi) + 0.5;
	    half4 color = tex2D (_MainTex, half2(u,v)); 	 	
		return color;
	  }
	}
	ENDCG 
	
Subshader {
 Pass {
	  ZTest Always Cull Off ZWrite Off

      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag
      ENDCG
  }
  
}

Fallback off
	
} // shader
