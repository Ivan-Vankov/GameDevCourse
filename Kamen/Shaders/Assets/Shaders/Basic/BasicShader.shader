Shader "Shader Demo/Basic Shader"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			// The data from the mesh
			struct appdata
			{
				// The position of the vertex in object space
				float4 vertex : POSITION;
				// List of data that can be provided from vertices: 
				// https://docs.unity3d.com/Manual/SL-VertexProgramInputs.html
			};

			// The data that will be passed to the fragment shader
			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			// The vertex shader function
			// It takes data from the mesh
			v2f vert(appdata v)
			{
				v2f o;
				// And converts the position from object space to clip space
                o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}

			// The fragment shader function
			// Gets the data from the vertex shader
			float4 frag(v2f i) : SV_Target
			{
				// But ignores it and makes a flat color instead
				float4 color = float4(1, 0.5, 0, 1);
				return color;
			}
			ENDCG
		}
	}
}
