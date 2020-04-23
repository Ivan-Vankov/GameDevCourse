Shader "Shader Demo/ColorLerp"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
        _Intensity("Tint Intensity", Range(0, 1)) = 0.1
        _Color1("Color1", Color) = (1.0, 0.1, 1.0, 1)
        _Color2("Color2", Color) = (0.1, 1.0, 0.1, 1)
	}

	SubShader
	{
		Tags 
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha

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
            float _Intensity;
            float4 _Color1;
            float4 _Color2;

			float4 frag(v2f i) : SV_Target
			{
                float4 color = tex2D(_MainTex, i.uv);
                float alpha = color.a;
                float4 tint = lerp(_Color1, _Color2, (sin(_Time.z) + 1) / 2.);
                color = lerp(color, tint, _Intensity);
                color.a = alpha;
				return color;
			}
			ENDCG
		}
	}
}
