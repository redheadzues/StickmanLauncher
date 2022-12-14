Shader "Custom/TextureMover"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
        _SpeedX("SpeedX", float) = 0.5
        _SpeedY("SpeedY", float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "IgnoreProjector"="True" "Queue" = "Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Zwrite off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _SpeedY;
            float _SpeedX;
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }



            fixed4 frag (v2f i) : SV_Target
            {
                i.uv.y -= _Time.y * _SpeedY;
                i.uv.x -= _Time.x * _SpeedX;
                fixed4 col = tex2D(_MainTex, i.uv);
                col *= _Color;

                return col;
            }
            ENDCG
        }
    }
}
