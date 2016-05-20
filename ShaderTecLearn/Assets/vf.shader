Shader "Sbin/vf" 
{

	SubShader 
	{
		pass
		{
			CGPROGRAM

			// vert 和 frag两个函数都必须编写.

			// 定义顶点函数名
			// 编译指令.
			#pragma vertex vert
			// 定义
			#pragma fragment frag

			// 顶点数据必须对数据处理 进行输出
			// 顶点必须输出float4 变量.
			// pos 没有使用这样的输出.
			// pos:POSITION被图形硬件做最后的处理.
			void vert(in float2 objPos:POSITION, out float4 pos:POSITION, out float4 col:COLOR)
			{
				pos=float4(objPos,0,1);
				//col = float4(0,0,1,1);
				col=pos;
			}

			// 不用在片段程序中直接使用pos:POSITION
			void frag(inout float4 col:COLOR)
			{
				// col=float4(0,1,0,1);

				// 16位 half.

				// fixed 定点数.


				// bool

				// int 32位精度.

				// 32位精度
				half r=1;
				half g=0;
				half b=0;
				half a=1;

				col=half4(r,g,b,a);
			}

			ENDCG
		}

	}

}
