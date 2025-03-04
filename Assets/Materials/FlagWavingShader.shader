Shader "Unlit/FlagWavingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaveSpeed ("Wave Speed", Float) = 1
        _WaveStrength ("Wave Strength", Float) = 0.1
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

struct appdata_t
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
float _WaveSpeed;
float _WaveStrength;

v2f vert(appdata_t v)
{
    v2f o;
    float wave = sin(v.vertex.y * 5 + _Time.y * _WaveSpeed) * _WaveStrength;
    v.vertex.x += wave;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = v.uv;
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
    return tex2D(_MainTex, i.uv);
}
            ENDCG
        }
    }
}
