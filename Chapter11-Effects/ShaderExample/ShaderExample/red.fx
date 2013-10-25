// Compile this shader with DirectX sdk fxc.exe to produce red.fx.ps

sampler2D input : register(s0);
float inputOpacity : register(c0);   

float4 main(float2 elementPosition : TEXCOORD) : COLOR
{
    float4 outputColor;
    
    //
    // Use the tex2D function to read input from the input
    //
    outputColor.a = tex2D(input, elementPosition).a*inputOpacity;
    outputColor.r = tex2D(input, elementPosition).a*inputOpacity;
    outputColor.g = 0.0f;
    outputColor.b = 0.0f;
    
    return outputColor;
}
