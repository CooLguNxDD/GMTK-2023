Shader "Custom/BLUR" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _BumpMap ("Normalmap", 2D) = "bump" {}
        _Size ("Size", Range(0, 20)) = 1
    }

    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }

        GrabPass { }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord: TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
            };

            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            float _Size;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uvgrab.xy = (v.vertex.xy/v.vertex.w + float2(1.0, 1.0)) * 0.5;
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target {
                float4 sum = float4(0,0,0,0);
                #define GRABPIXEL(weight,offset) tex2D( _GrabTexture, i.uvgrab.xy + _GrabTexture_TexelSize.xy * offset * _Size ) * weight
                sum += GRABPIXEL(0.05, -4.0);
                sum += GRABPIXEL(0.09, -3.0);
                sum += GRABPIXEL(0.12, -2.0);
                sum += GRABPIXEL(0.15, -1.0);
                sum += GRABPIXEL(0.18,  0.0);
                sum += GRABPIXEL(0.15, +1.0);
                sum += GRABPIXEL(0.12, +2.0);
                sum += GRABPIXEL(0.09, +3.0);
                sum += GRABPIXEL(0.05, +4.0);
                return sum;
            }
            ENDCG
        }

        GrabPass { }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord: TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float4 uvgrab : TEXCOORD0;
            };

            sampler2D _GrabTexture;
            float4 _GrabTexture_TexelSize;
            float _Size;

            v2f vert (appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uvgrab.xy = (v.vertex.xy/v.vertex.w + float2(1.0, 1.0)) * 0.5;
                return o;
            }

            fixed4 frag( v2f i ) : SV_Target {
                float4 sum = float4(0,0,0,0);
                #define GRABPIXEL(weight,offset) tex2D( _GrabTexture, i.uvgrab.xy + float2(0.0, _GrabTexture_TexelSize.y) * offset * _Size ) * weight
                sum += GRABPIXEL(0.05, -4.0);
                sum += GRABPIXEL(0.09, -3.0);
                sum += GRABPIXEL(0.12, -2.0);
                sum += GRABPIXEL(0.15, -1.0);
                sum += GRABPIXEL(0.18,  0.0);
                sum += GRABPIXEL(0.15, +1.0);
                sum += GRABPIXEL(0.12, +2.0);
                sum += GRABPIXEL(0.09, +3.0);
                sum += GRABPIXEL(0.05, +4.0);
                return sum;
            }
            ENDCG
        }
    }
}
