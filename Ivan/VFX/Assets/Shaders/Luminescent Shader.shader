Shader "Custom/Luminescent"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color", color) = (1, 1, 1, 1)
		_Brightness("Brightness", Range(1, 3)) = 1
	}

	SubShader
	{
		Tags {
			"RenderType" = "Transparent" 
			"Queue" = "Transparent" 
		}

		Blend One One

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
				float4 vertexColor : COLOR;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 vertexColor : COLOR;
			};

			sampler2D _MainTex;
			fixed4 _Color;
			float _Brightness;

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				o.vertexColor = v.vertexColor;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				return tex2D(_MainTex, i.uv) * i.vertexColor * _Color * _Brightness;
			}
			ENDCG
		}
	}
}
