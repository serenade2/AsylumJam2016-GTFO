Shader "Custom/Wave_CullingFront"
{
	Properties
	{
		_MainTex("Texture Image", 2D) = "white" {}
		_TintColor("Tint color", Color) = (1,1,1,1)
		_TranslateX("Translation X", Float) = 0
		_AmpX("Amplitude X", Float) = 0
		_FreqX("Frequency X", Float) = 0
		_ScaleX("Scale X", Float) = 0.1
		_TranslateY("Translation Y", Float) = 0
		_AmpY("Amplitude Y", Float) = 0
		_FreqY("Frequency Y", Float) = 0
		_ScaleY("Scale Y", Float) = 0.1
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
		//Cull Front
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		CGPROGRAM

#pragma target 3.0
#pragma vertex vert_img
#pragma fragment frag

#include "UnityCG.cginc"

		uniform sampler2D _MainTex;
	uniform float4 _MainTex_ST;
	uniform float4 _TintColor;

	uniform float _TranslateX;
	uniform float _AmpX;
	uniform float _FreqX;
	uniform float _ScaleX;

	uniform float _TranslateY;
	uniform float _AmpY;
	uniform float _FreqY;
	uniform float _ScaleY;

	uniform float __Time;

	struct vertexInput
	{
		float4 vertex : POSITION;
		float4 texcoord : TEXCOORD0;
	};

	struct vertexOutput
	{
		float4 pos : SV_POSITION;
		float4 tex : TEXCOORD0;
	};

	vertexOutput vert(vertexInput input)
	{
		vertexOutput output;
		output.tex = input.texcoord;
		output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
		return output;
	}

	float4 frag(vertexOutput input) : COLOR
	{
		fixed2 cord = _MainTex_ST.xy * input.tex.xy + _MainTex_ST.zw;
		cord.x += (_AmpX * sin(_FreqX * cord.y + _ScaleX * __Time)) + _TranslateX * __Time;
		cord.y += (_AmpY * sin(_FreqY * cord.x + _ScaleY * __Time)) + -_TranslateY * __Time;
		return tex2D(_MainTex, cord) * _TintColor;
	}

		ENDCG
	}
	}
}
