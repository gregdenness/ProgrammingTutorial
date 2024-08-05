using System;

class Input {

    static public double xAxis;
    static public double yAxis;
    static public Dictionary<string, bool> buttonsDown = new Dictionary<string, bool>();

    // ------------------------------------------------------------------------------------
    // Name: Init
    // ------------------------------------------------------------------------------------
    public static void Init() {
        buttonsDown["a"] = false;
        buttonsDown["b"] = false;
        buttonsDown["x"] = false;
        buttonsDown["t"] = false;
        buttonsDown["up"] = false;
        buttonsDown["down"] = false;
        buttonsDown["left"] = false;
        buttonsDown["right"] = false;
    }

    // ------------------------------------------------------------------------------------
    // Name: GetXAxis
    // ------------------------------------------------------------------------------------
    public static double GetXAxis() {
        return xAxis;
    }

    // ------------------------------------------------------------------------------------
    // Name: GetYAxis
    // ------------------------------------------------------------------------------------
    public static double GetYAxis() {
        return yAxis;
    }

    // ------------------------------------------------------------------------------------
    // Name: GetButtonDown
    // ------------------------------------------------------------------------------------
    public static bool GetButtonDown(string name) {
        return buttonsDown[name];
    }
}

