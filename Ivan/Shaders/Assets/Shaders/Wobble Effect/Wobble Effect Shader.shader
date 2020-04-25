Shader "Shader Demo/Wobble Effect Shader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DisplaceTex("Displacement Texture", 2D) = "white" {}
		_Intensity("Intensity", Range(0, 0.1)) = 0.01
		_WobbleSpeed("Wobble Speed", Range(0.5, 3)) = 1
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;
			sampler2D _DisplaceTex;
			float _Intensity;
			float _WobbleSpeed;

			float4 frag(v2f i) : SV_Target
			{
				float2 displacementUV = float2(i.uv.x + _Time.x * _WobbleSpeed, 
                                               i.uv.y + _Time.x * _WobbleSpeed);

				float2 displacement = tex2D(_DisplaceTex, displacementUV).rg;
				displacement = ((displacement * 2) - 1) * _Intensity;

				float4 color = tex2D(_MainTex, i.uv + displacement);
				return color;
			}
			ENDCG
		}
	}
}
