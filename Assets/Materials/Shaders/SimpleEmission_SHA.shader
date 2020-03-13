Shader "Roller/Glow"
{
    Properties
    {
		_Color("Emissive Color", Color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100


			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows

			#include "UnityCG.cginc"

			sampler2D _MainTex;

			struct Input
			{
				float2 uv_MainTex;
			};

			fixed4 _Color;

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
				o.Emission = _Color * o.Albedo;
			}

            ENDCG
        }
		Fallback "Diffuse"
}
