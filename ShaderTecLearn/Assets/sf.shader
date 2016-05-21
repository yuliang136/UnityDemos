Shader "Sbin/sf" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5  	// 高光
		_Metallic ("Metallic", Range(0,1)) = 0.0		// 金属光泽
	}
	SubShader {
		Tags { "RenderType"="Opaque" }	// 渲染类型. 不透明物体
		LOD 200							//
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		// surf 函数名称.
		// Standard 函数.
		#pragma surface surf Standard fullforwardshadows

		// 如果没有这句话 默认使用shader model 2.0
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		// 变量声明.
		// 上面定义的属性自动对应于CG里_MainTex属性
		// 贴图要特殊处理一下

		// Properties 使用的2D 对应CG中的sampler2D
		// Properties Color CG中的fixed4
		// Properties Range CG中的half
		 
		sampler2D _MainTex;
		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		struct Input 
		{
			// uv 必须名字接口.
			// _MainTex属性名称.
			float2 uv_MainTex;
		};



		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
