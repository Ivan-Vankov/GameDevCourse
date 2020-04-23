Shader "Shader Demo/WavyUvs"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
        _Amplitude("Wave Amplitude", Range(0.1, 2)) = 0.5
        _Frequency("Wave Frequency", Range(0.1, 5)) = 3
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
            float _Amplitude;
            float _Frequency;

			float4 frag(v2f i) : SV_Target
			{
                float2 wavyUV = i.uv + _Amplitude * sin(_Time.y + i.uv.x * _Frequency);
				float4 color = tex2D(_MainTex, wavyUV);
				return color;
			}
			ENDCG
		}
	}
}
