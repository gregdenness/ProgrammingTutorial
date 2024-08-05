using SDL2;
using System;
using System.Xml.Linq;

class Graphics {

    static public IntPtr window;
    static public IntPtr renderer;
    static float scale;

    static public int ScreenWidth {
        get { 
            int w, h;
            SDL.SDL_GetWindowSize(window, out w, out h);
            return (int)(w  / scale); 
            }   
    }

    static public int ScreenHeight {
        get { 
            int w, h;
            SDL.SDL_GetWindowSize(window, out w, out h);
            return (int)(h /scale); 
            }   
    }

    // ------------------------------------------------------------------------------------
    // Name: SetRenderScale
    // ------------------------------------------------------------------------------------
    public static void SetRenderScale(float scale) {
        Graphics.scale = scale;
        SDL.SDL_RenderSetScale(renderer, scale, scale);
    }

    // ------------------------------------------------------------------------------------
    // Name: Clear
    // ------------------------------------------------------------------------------------
    public static void Clear(int r, int g, int b) {
        // Sets the color that the screen will be cleared with.
        SDL.SDL_SetRenderDrawColor(renderer, (byte)r, (byte)g, (byte)b, 255);

        // Clears the current render surface.
        SDL.SDL_RenderClear(renderer);
    }

    // ------------------------------------------------------------------------------------
    // Name: Present
    // ------------------------------------------------------------------------------------
    public static void Present() {
        // Switches out the currently presented render surface with the one we just did work on.
        SDL.SDL_RenderPresent(renderer);
    }

    // ------------------------------------------------------------------------------------
    // Name: SetDrawColor
    // ------------------------------------------------------------------------------------
    public static void SetDrawColor(int r, int g, int b, int a=255 ) {
        SDL.SDL_SetRenderDrawColor(renderer, (byte)r, (byte)g, (byte)b, (byte)a );
    }

    // ------------------------------------------------------------------------------------
    // Name: DrawPixel
    // ------------------------------------------------------------------------------------
    public static void DrawPixel( double x, double y ) {
        SDL.SDL_RenderDrawPoint(renderer, (int)x, (int)y);
    }

    // ------------------------------------------------------------------------------------
    // Name: DrawPixel
    // ------------------------------------------------------------------------------------
    public static void DrawPixel( double x, double y, int r, int g, int b, int a=255 ) {
        SetDrawColor(r,g,b,a);
        SDL.SDL_RenderDrawPoint(renderer, (int)x, (int)y);
    }

    // ------------------------------------------------------------------------------------
    // Name: DrawLine
    // ------------------------------------------------------------------------------------
    public static void DrawLine( double x1, double y1, double x2, double y2 ) {
        SDL.SDL_RenderDrawLine(renderer, (int)x1, (int)y1, (int)x2, (int)y2);
    }

    // ------------------------------------------------------------------------------------
    // Name: DrawLine
    // ------------------------------------------------------------------------------------
    public static void DrawLine( double x1, double y1, double x2, double y2, int r, int g, int b, int a=255 ) {
        SetDrawColor(r,g,b,a);
        SDL.SDL_RenderDrawLine(renderer, (int)x1, (int)y1, (int)x2, (int)y2);
    }

    // ------------------------------------------------------------------------------------
    // Name: DrawRect
    // ------------------------------------------------------------------------------------
    public static void DrawRect( double x, double y, double width, double height ) {
        var rect = new SDL.SDL_Rect 
        { 
            x = (int)x,
            y = (int)y,
            w = (int)width,
            h = (int)height
        };
        SDL.SDL_RenderFillRect(renderer, ref rect);
    }

    // ------------------------------------------------------------------------------------
    // Name: DrawRect
    // ------------------------------------------------------------------------------------
    public static void DrawRect( double x, double y, double width, double height, int r, int g, int b, int a=255 ) {
        SetDrawColor(r,g,b,a);
        var rect = new SDL.SDL_Rect 
        { 
            x = (int)x,
            y = (int)y,
            w = (int)width,
            h = (int)height
        };
        SDL.SDL_RenderFillRect(renderer, ref rect);
    }
    
}

