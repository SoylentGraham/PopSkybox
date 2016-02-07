Shader "NewChromantics/SkyDebug"
{
    Properties
    {
    	_MainTex ("Texture", 2D) = "white" {}
    }

    CGINCLUDE

    #include "UnityCG.cginc"

    struct appdata
    {
        float4 position : POSITION;
        float3 texcoord : TEXCOORD0;
    };
    
    struct v2f
    {
        float4 position : SV_POSITION;
        float3 texcoord : TEXCOORD0;
    };
    
    sampler2D _MainTex;
 
	#include "PopCommon.cginc"
	 
    v2f vert (appdata v)
    {
        v2f o;
        o.position = mul (UNITY_MATRIX_MVP, v.position);
        o.texcoord = v.texcoord;
        return o;
    }
    
     
    fixed4 frag (v2f i) : COLOR
    {
    	float3 uv3 = normalize(i.texcoord);
    	uv3 += float3(1,1,1);
    	uv3 /= float3(2,2,2);
    	return float4( uv3.x, uv3.y, uv3.z, 1 );
    }

    ENDCG

    SubShader
    {
        Tags { "RenderType"="Background" "Queue"="Background" }
        Pass
        {
            ZWrite Off
            Cull Off
            Fog { Mode Off }
            CGPROGRAM
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma vertex vert
            #pragma fragment frag
            ENDCG
        }
    }
}
