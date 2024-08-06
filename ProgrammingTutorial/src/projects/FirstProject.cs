using SDL2;
using System;

class FirstProject : BaseProject{

    public override void Render()
    {
        // This is called every frame when we want to draw things
        Graphics.DrawPixel(1,1);
    }
}

