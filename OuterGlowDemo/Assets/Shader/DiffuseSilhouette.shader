// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:33776,y:32688,varname:node_9361,prsc:2|custl-7357-OUT;n:type:ShaderForge.SFN_Fresnel,id:276,x:32696,y:32790,varname:node_276,prsc:2|NRM-7280-OUT;n:type:ShaderForge.SFN_NormalVector,id:7280,x:32434,y:32720,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:4073,x:32438,y:33091,varname:node_4073,prsc:2;n:type:ShaderForge.SFN_Dot,id:8328,x:32762,y:33079,varname:node_8328,prsc:2,dt:1|A-7280-OUT,B-4073-OUT;n:type:ShaderForge.SFN_Tex2d,id:5791,x:32813,y:33240,ptovrint:False,ptlb:DiffuseMap,ptin:_DiffuseMap,varname:node_5791,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:4961,x:32985,y:33079,varname:node_4961,prsc:2|A-8328-OUT,B-5791-RGB;n:type:ShaderForge.SFN_Color,id:4624,x:32734,y:32530,ptovrint:False,ptlb:SilhouetteColor,ptin:_SilhouetteColor,varname:node_4624,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.8344827,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2369,x:33204,y:32532,varname:node_2369,prsc:2|A-7818-OUT,B-4624-RGB,C-3429-OUT;n:type:ShaderForge.SFN_Slider,id:7818,x:32628,y:32412,ptovrint:False,ptlb:SilhouetteIntensity,ptin:_SilhouetteIntensity,varname:node_7818,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Add,id:7357,x:33511,y:32857,varname:node_7357,prsc:2|A-2369-OUT,B-4961-OUT;n:type:ShaderForge.SFN_Slider,id:620,x:32850,y:32960,ptovrint:False,ptlb:SilhouetteWidth,ptin:_SilhouetteWidth,varname:node_620,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:1.798971,max:4;n:type:ShaderForge.SFN_Power,id:3429,x:33006,y:32630,varname:node_3429,prsc:2|VAL-276-OUT,EXP-6384-OUT;n:type:ShaderForge.SFN_Exp,id:6384,x:33006,y:32775,varname:node_6384,prsc:2,et:1|IN-620-OUT;proporder:5791-4624-620-7818;pass:END;sub:END;*/

Shader "Shader Forge/DiffuseSilhouette" {
    Properties {
        _DiffuseMap ("DiffuseMap", 2D) = "white" {}
        _SilhouetteColor ("SilhouetteColor", Color) = (0,0.8344827,1,1)
        _SilhouetteWidth ("SilhouetteWidth", Range(1, 4)) = 1.798971
        _SilhouetteIntensity ("SilhouetteIntensity", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _SilhouetteColor;
            uniform float _SilhouetteIntensity;
            uniform float _SilhouetteWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float3 finalColor = ((_SilhouetteIntensity*_SilhouetteColor.rgb*pow((1.0-max(0,dot(i.normalDir, viewDirection))),exp2(_SilhouetteWidth)))+(max(0,dot(i.normalDir,lightDirection))*_DiffuseMap_var.rgb));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _DiffuseMap; uniform float4 _DiffuseMap_ST;
            uniform float4 _SilhouetteColor;
            uniform float _SilhouetteIntensity;
            uniform float _SilhouetteWidth;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float4 _DiffuseMap_var = tex2D(_DiffuseMap,TRANSFORM_TEX(i.uv0, _DiffuseMap));
                float3 finalColor = ((_SilhouetteIntensity*_SilhouetteColor.rgb*pow((1.0-max(0,dot(i.normalDir, viewDirection))),exp2(_SilhouetteWidth)))+(max(0,dot(i.normalDir,lightDirection))*_DiffuseMap_var.rgb));
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
