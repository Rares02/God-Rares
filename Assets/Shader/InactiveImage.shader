Shader "Unlit/InactiveImage"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        [MyToggle] _BlackAndWhite ("_BlackAndWhite", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

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

            sampler2D _MainTex;
            float _BlackAndWhite;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float4 col = tex2D(_MainTex, i.uv);
                float bwColor = 0.299 * col.r + 0.587 * col.g + 0.114 * col.b;
                col = _BlackAndWhite * float4(bwColor, bwColor, bwColor, 1) + (1 - _BlackAndWhite) * col;

                return col;
            }
            ENDCG
        }
    }
}
