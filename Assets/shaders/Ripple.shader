Shader "Custom/Ripple_CullingBack"
{
	Properties
	{
		_MainTex("RGBA Texture Image", 2D) = "white" {}
		tintColor("Tint color", Color) = (1,1,1,1)
		depth("Depth", Float) = 1
		size("Size", Float) = 1
		pX("Point X", Float) = 0.5
		pY("Point Y", Float) = 0.5
		speed("Speed", Float) = 0
		attenuationRate("Attenuation Rate", Float) = 0.01
		__Time("Time", Float) = 0
	}
		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"RenderType" = "Transparent"
	}
		Pass
	{
		//Cull Back
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag

#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
	uniform float4 tintColor;

	uniform float depth;
	uniform float size;
	uniform float pX;
	uniform float pY;
	uniform float speed;
	uniform float attenuationRate;
	uniform float __Time;

	uniform float test;

	fixed4 frag(v2f_img i) : SV_Target
	{
		fixed2 cord = i.uv; //= -1.0 + 2.0 * i.uv;
	cord.x += -pY;// +0.5;
	cord.y += -pX;// +0.5;
	fixed len = length(cord);
	cord = i.uv + (cord / len*depth)*cos(len*12.0 / size - __Time*speed)*0.03 / exp2(__Time * attenuationRate);
	fixed4 color = tex2D(_MainTex, cord);
	color.r = color.r * tintColor.r;
	color.g = color.g * tintColor.g;
	color.b = color.b * tintColor.b;
	color.a = color.a * tintColor.a;
	return color;
	}
		ENDCG
	}
	}
}
