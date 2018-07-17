﻿Shader "Custom/OutterGlow" {
	Properties{
		_MainTex("Texture",2D) = "white"{}
	_Color("Color",Color) = (1,1,1,1)
		_Factor("Factor",Range(0,10)) = 1
		_SampleRange("Sample Range",Range(0,10)) = 7
		_SampleInterval("Sample Interval",vector) = (1,1,0,0)
		_TexSize("Texture Size",vector) = (256,256,0,0)
	}
		SubShader{
		Tags
	{ "RenderType" = "Opaque"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
	}
		LOD 200
		Pass{
		Cull back
		Lighting Off
		ZWrite Off
		Offset -1, -1
		Fog{ Mode Off }

		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		sampler2D _MainTex;
	float4 _Color;
	float _Factor;
	float _SampleRange;
	float2 _TexSize;
	float2 _SampleInterval;

	struct appdata {
		float4 vertex: POSITION;
		float2 texcoord:TEXCOORD0;
		fixed4 color : COLOR;
	};

	struct v2f {
		float4 vertex : SV_POSITION;
		half2 uv : TEXCOORD0;
		fixed4 color : COLOR;
	};

	v2f vert(appdata v) {
		v2f o;
		o.vertex = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord;
		o.color = v.color;
		return o;
	}

	half4 frag(v2f i) : COLOR{
		int range = (int)_SampleRange;
	float radiusX = _SampleInterval.x / _TexSize.x;
	float radiusY = _SampleInterval.y / _TexSize.y;
	float inner = 0;
	float outter = 0;
	int count = 0;

	//?没看懂，这一步是干啥的
	for (int k = -range; k <= range; ++k)
	{
		for (int j = -range; j <= range; ++j)
		{
			float4 m = tex2D(_MainTex, float2(i.uv.x + k * radiusX, i.uv.y + j * radiusY));
			outter += 1 - m.a;
			inner += m.a;
			count += 1;
		}
	}
	inner /= count;
	outter /= count;

	float4 col = tex2D(_MainTex, i.uv)*i.color;
	float out_alpha = max(col.a, inner);

	col.rgb = col.rgb + (1 - col.a)*_Factor*_Color.a*_Color.rgb;
	col.a = out_alpha;
	return col;

	}
		ENDCG
	}

	}

}
