Shader "Instagram Filters/Vignette Shader"
{
    Properties
    {
        _MainTex ("Vignette", 2D) = "white" {}
		_Intensity ("Intensity", Range(0, 0.5)) = 0.2
    }
    SubShader
    {
		Tags
		{
			"Queue" = "Transparent"
			"PreviewType" = "Plane"
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			float _Intensity;

            fixed4 frag (v2f i) : SV_Target
            {
				float4 color = tex2D(_MainTex, i.uv);
				// Get the uv data and map it to [-1,1]
				float2 dist = i.uv * 2 - 1;
				// dot(dist, dist) will give large values for points around the edge of the dist square
				//   if we do color *= dist.x now we will get the base color around the edges and black in the middle
				// when inverted with (1 -) it becomes black around the edges and the base color in the middle
				dist.x = 1 - dot(dist, dist) * _Intensity;
				color *= dist.x;
				return color;
            }
            ENDCG
        }
    }
}
