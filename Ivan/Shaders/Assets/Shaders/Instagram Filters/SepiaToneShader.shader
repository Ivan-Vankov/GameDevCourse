Shader "Instagram Filters/Sepia Tone Shader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Intensity ("Intensity", Range(0, 1)) = 0
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
			ZWrite Off
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

			// Formula from https://stackoverflow.com/questions/1061093/how-is-a-sepia-tone-created
            fixed4 frag (v2f i) : SV_Target
            {
				fixed4 color = tex2D(_MainTex, i.uv);

				fixed4 final = color;
				final.r = color.r * 0.393 + color.g * 0.769 + color.b * 0.189;
				final.g = color.r * 0.349 + color.g * 0.686 + color.b * 0.168;
				final.b = color.r * 0.272 + color.g * 0.534 + color.b * 0.131;
				
				return lerp(color, final, _Intensity);
            }
            ENDCG
        }
    }
}
