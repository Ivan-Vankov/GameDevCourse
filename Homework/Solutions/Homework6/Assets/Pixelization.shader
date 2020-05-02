Shader "Custom/Pixelize"
{
    Properties
    {
      _MainTex("Texture", 2D) = "white" {}
      _PixelSize("Pixel Size", Float) = 7.0
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
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _PixelSize;

            fixed4 frag(v2f i) : SV_Target
            {
                // How big the pixels should be relative to the screen size
                float2 scalingCoeff = _ScreenParams.xy / _PixelSize;

                // All the uvs in some vicinity are floored to a single uv
                float2 pixelatedUV = floor(i.uv * scalingCoeff) / scalingCoeff;
                return tex2D(_MainTex, pixelatedUV);
            }
            ENDCG
        }
    }
}
