Shader "Sbin/ff1" 
{
	properties
	{
		_Color("Main Color", color)=(1,1,1,1)
		_Ambient("Ambient",color)=(0.3,0.3,0.3,0.3)
		_Specular("Specular",color)=(1,1,1,1)
		_Shininess("Shininess",range(0,8))=4
		_Emission("Emission",color)=(1,1,1,1)
	}

	SubShader 
	{
		pass
		{
			// 颜色信息. RGBA
			// 通道中渲染的顶点颜色.
			// 小括号是固定值.
			// 中括号是参数值.
			//color(1,0,0,1)
			//color[_Color]

			// 材质命令快
			material
			{
				// 漫反射. 物体固有颜色.
				diffuse[_Color]

				ambient[_Ambient]

				specular[_Specular]

				// specular强度.
				shininess[_Shininess]

				// 自发光.
				emission[_Emission]
			}

			// lighting 固定管线.
			lighting on

			// 使用specular必须添加.
			// 在集中地方进行反光.
			separatespecular on
		}
				
	}

}
