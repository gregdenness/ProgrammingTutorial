using SDL2;
using System;
using System.Collections.Generic;


class Tutorial {

    BaseProject project = new FirstProject();

    // ------------------------------------------------------------------------------------
    // Name: Start
    // ------------------------------------------------------------------------------------
    public void Start()
    {
        // How zoomed in / chunky do you want the pixels to be? Set this to 1 for normal size
        // pixels, the higher the value the bigger they are.
        Graphics.SetRenderScale(4);

        project.Start();
    }

    // ------------------------------------------------------------------------------------
    // Name: Update
    // ------------------------------------------------------------------------------------
    public void Update()
    {
        // This is called every frame
        project.Update();
    }

    // ------------------------------------------------------------------------------------
    // Name: Render
    // ------------------------------------------------------------------------------------
    public void Render()
    {
        // Clear the screen to a color
        Graphics.Clear(0, 0, 0);

        // Set the color to draw things with (if you dont specify a color when drawing)
        Graphics.SetDrawColor(255,255,255, 255);     
        
        // This is also called every frame, like Update, put any code in here
        // for drawing things using Graphics
        
        project.Render();
     
        // Finish drawing and make it actually appear on the screen
        Graphics.Present();
    }
}

