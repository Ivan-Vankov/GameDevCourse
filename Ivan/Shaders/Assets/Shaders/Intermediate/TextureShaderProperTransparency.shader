Shader "Shader Demo/Texture Shader Proper Transparency"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader
	{
		// Allows this transparent sprite to render after opaque sprites
		Tags 
		{
			"Queue" = "Transparent"
		}

		Pass
		{
			// Traditional transparency blending
			// SrcColor * SrcAlpha + DstColor * (1 - SrcAlpha) 
			Blend SrcAlpha OneMinusSrcAlpha
			// More at: https://docs.unity3d.com/Manual/SL-Blend.html

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

			// Don't forget to add _MainTex in the scope of the CGPROGRAM
			// Otherwise it wont compile
			sampler2D _MainTex;

			float4 frag(v2f i) : SV_Target
			{
				// Use the tex2D function to get the texture data at the perticular uv
				float4 color = tex2D(_MainTex, i.uv);
				return color;
			}
			ENDCG
		}
	}
}
