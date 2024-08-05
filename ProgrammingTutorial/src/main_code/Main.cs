using SDL2;
using System;


IntPtr window;
IntPtr renderer;
IntPtr gameController = IntPtr.Zero;
bool running = true;

Tutorial tutorial = new Tutorial();

Setup();
tutorial.Start();

while (running)
{
    PollEvents();
    tutorial.Update();
    tutorial.Render();
}

CleanUp();


// ------------------------------------------------------------------------------------
// Name: Setup
// ------------------------------------------------------------------------------------
void Setup() 
{
    // Initilizes SDL.
    if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO | SDL.SDL_INIT_GAMECONTROLLER ) < 0)
    {
        Console.WriteLine($"There was an issue initializing SDL. {SDL.SDL_GetError()}");
    }

    // Create a new window given a title, size, and passes it a flag indicating it should be shown.
    window = SDL.SDL_CreateWindow(
        "Programming Tutorial",
        SDL.SDL_WINDOWPOS_UNDEFINED, 
        SDL.SDL_WINDOWPOS_UNDEFINED, 
        512, 
        512, 
        SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN  );

  
    if (window == IntPtr.Zero)
    {
        Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
    }

    // Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
    renderer = SDL.SDL_CreateRenderer(
        window,
        -1,
        SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED |
        SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

    if (renderer == IntPtr.Zero)
        Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");

    
    SDL.SDL_SetRenderDrawBlendMode(renderer, SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND);

    getGameController();

    Graphics.renderer = renderer;
    Graphics.window = window;
    Input.Init();
    
}


// ------------------------------------------------------------------------------------
// Name: getGameController
// ------------------------------------------------------------------------------------
void getGameController()
{
    if (SDL.SDL_NumJoysticks() > 0)
    {
        for (int i = 0; i < SDL.SDL_NumJoysticks(); i++)
        {
            if (SDL.SDL_IsGameController(i) == SDL.SDL_bool.SDL_TRUE )
            {
                gameController = SDL.SDL_GameControllerOpen(i);
                if (gameController != IntPtr.Zero)
                {
                    Log.Write("Game Controller connected!");
                    break;
                }
                else
                {
                    Log.Write($"Could not open game controller! SDL_Error: {SDL.SDL_GetError()}");
                }
            }
        }
    }
    else {
        Log.Write("No controllers detected");
    }
}

// ------------------------------------------------------------------------------------
// Name: PollEvents
// ------------------------------------------------------------------------------------
void PollEvents()
{  
    // Check to see if there are any events and continue to do so until the queue is empty.
    while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
    {
        
        if (e.type == SDL.SDL_EventType.SDL_QUIT) { 
            running = false;
            return;
        }

        if (e.type == SDL.SDL_EventType.SDL_CONTROLLERAXISMOTION){
            double DEAD_ZONE = 0.09;
            if (e.caxis.axis == (byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTX)
            {
                double val = (double)e.caxis.axisValue / 32768.0;
                if (val > -DEAD_ZONE && val < DEAD_ZONE)
                    val = 0;

                Input.xAxis = val;
   
            }
            else if (e.caxis.axis == (byte)SDL.SDL_GameControllerAxis.SDL_CONTROLLER_AXIS_LEFTY)
            {
                double val = (double)e.caxis.axisValue / 32768.0;
                if (val > -DEAD_ZONE && val < DEAD_ZONE)
                    val = 0;

                Input.yAxis = val;
            }
        }
        
        if (e.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONDOWN){
            switch (e.cbutton.button)
            {
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A:
                    Input.buttonsDown["a"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B:
                    Input.buttonsDown["b"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X:
                    Input.buttonsDown["x"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y:
                    Input.buttonsDown["y"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP:
                    Input.buttonsDown["up"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN:
                    Input.buttonsDown["down"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT:
                    Input.buttonsDown["left"] = true;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT:
                    Input.buttonsDown["right"] = true;
                    break;
            }
        }

        if (e.type == SDL.SDL_EventType.SDL_CONTROLLERBUTTONUP){
            switch (e.cbutton.button)
            {
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_A:
                    Input.buttonsDown["a"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_B:
                    Input.buttonsDown["b"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_X:
                    Input.buttonsDown["x"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_Y:
                    Input.buttonsDown["y"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_UP:
                    Input.buttonsDown["up"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_DOWN:
                    Input.buttonsDown["down"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_LEFT:
                    Input.buttonsDown["left"] = false;
                    break;
                case (byte)SDL.SDL_GameControllerButton.SDL_CONTROLLER_BUTTON_DPAD_RIGHT:
                    Input.buttonsDown["right"] = false;
                    break;
            }
        }
    }
}

// ------------------------------------------------------------------------------------
// Name: CleanUp
// ------------------------------------------------------------------------------------
void CleanUp()
{
    SDL.SDL_DestroyRenderer(renderer);
    SDL.SDL_DestroyWindow(window);
    SDL.SDL_Quit();
}