using SDL2;
using System;
using System.Collections.Generic;


class FirstProject : BaseProject{

    // ------------------------------------------------------------------------------------
    // Name: Start
    // ------------------------------------------------------------------------------------
    public override void Start()
    {
        // This is called once, on the first frame
    }

    // ------------------------------------------------------------------------------------
    // Name: Update
    // ------------------------------------------------------------------------------------
    public override void Update()
    {
        // This is called every frame
    }

    // ------------------------------------------------------------------------------------
    // Name: Render
    // ------------------------------------------------------------------------------------
    public override void Render()
    {
        // This is called every frame when we want to draw things
        Graphics.DrawPixel(1,1);
    }
}

