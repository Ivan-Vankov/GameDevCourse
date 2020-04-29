Shader "Shader Demo/Basic Shader With UVs"
{
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
				// Aditionally get the uvs
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				// Add them to v2f too
				float2 uv : TEXCOORD0;
			};

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				// Pass them in the vertex shader function (no conversion function needed)
				o.uv = v.uv;
				return o;
			}

			float4 frag(v2f i) : SV_Target
			{
				// And color the mesh based on the uvs
				float4 color = float4(i.uv, 0, 1);
				return color;
			}
			ENDCG
		}
	}
}
