Shader "Shader Demo/Texture Shader With Broken Transparency"
{
	// Expose the texture property and default it to white 
	// It may work without the {} at the end (depends on the unity version)
	// Shader properties syntax: https://docs.unity3d.com/Manual/SL-Properties.html
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}

	SubShader
	{
        Tags
        {
            "PreviewType" = "Plane"
        }

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

			// Don't forget to add _MainTex in the scope of the CGPROGRAM
			// Otherwise it wont compile
			sampler2D _MainTex;

			float4 frag(v2f i) : SV_Target
			{
				// Use the tex2D function to get the texture data at the particular uv
				float4 color = tex2D(_MainTex, i.uv);
				return color;
			}
			ENDCG
		}
	}
}
