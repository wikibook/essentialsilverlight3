// Compile this shader with DirectX sdk fxc.exe to produce mask.fx.ps

sampler2D input : register(s0);
sampler2D mask : register(s1);

float4 main(float2 elementPosition : TEXCOORD) : COLOR
{
    return tex2D(input, elementPosition)
           * tex2D(mask, elementPosition);
}
