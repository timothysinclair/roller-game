﻿Shader "Roller/Billboard"
{
	Properties
	{
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		_MainTex2("Texture2", 2D) = "white" {}
		[HDR]_EmissionColor("Color", Color) = (1, 1, 1, 1)
		_EmissionMap("Emission Texture", 2D) = "white"{}

		_BlendTex("Blend Texture", 2D) = "white" {}
		_Blend("Blend Value", Range(0, 1)) = 0.0
	}
		SubShader
		{
			Tags { "RenderType" = "Opaque" }
			LOD 100
				CGPROGRAM
				#pragma surface surf Standard fullforwardshadows

				sampler2D _MainTex;
				sampler2D _MainTex2;

				struct Input
				{
					float2 uv_MainTex;
					float2 uv_MainTex2;
				};

				fixed4 _Color;
				half _Blend;

				sampler2D _EmissionMap;
				fixed4 _EmissionColor;

				sampler2D _BlendTex;

				void surf(Input IN, inout SurfaceOutputStandard o)
				{
					half blendVal = tex2D(_BlendTex, IN.uv_MainTex).r;
					half finBlend = (blendVal - _Blend) * _Color;

					fixed4 c = lerp(tex2D(_MainTex, IN.uv_MainTex), tex2D(_MainTex2, IN.uv_MainTex2), finBlend);
					o.Albedo = c.rgb;
					o.Emission = _EmissionColor * tex2D(_EmissionMap, IN.uv_MainTex) * o.Albedo;

					/*fixed4 c = lerp(tex2D(_MainTex, IN.uv_MainTex), tex2D(_MainTex2, IN.uv_MainTex2), _Blend) * _Color;
					o.Albedo = c.rgb;*/
				}

				ENDCG
		}

	Fallback "Diffuse"
}
