using UnityEngine;

namespace InputReader
{
    public static class InputSystem 
    {
        public static IInputReader KeyboardTesting(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode roll, KeyCode attack) => new AirconsoleController(xAxis,yAxis,interact,jump,roll, attack);
        public static IInputReader KeyboardTesting() => new AirconsoleController(
            "Horizontal", 
            "Vertical", 
            KeyCode.F, 
            KeyCode.Space, 
            KeyCode.Mouse1, 
            KeyCode.Mouse0);

        public static IInputReader KeyboardMouseTesting(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode roll, KeyCode attack) => new AirconsoleController(xAxis, yAxis, interact, jump, roll, attack);
        public static IInputReader KeyboardMouseTesting() => new AirconsoleController(
            "KeyboardMouseHorizontal",
            "KeyboardMouseVertical",
            KeyCode.F,
            KeyCode.Space,
            KeyCode.Mouse1,
            KeyCode.Mouse0);

        public static IInputReader Joy1Testing(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode roll, KeyCode attack) => new AirconsoleController(xAxis,yAxis,interact,jump,roll, attack);
        
        public static IInputReader Joy1Testing() =>  new AirconsoleController(
                            "Joystick1Horizontal",
                            "Joystick1Vertical",
                            KeyCode.Joystick1Button0,
                            KeyCode.Joystick1Button1,
                            KeyCode.Joystick1Button2, 
                            KeyCode.Joystick1Button3);
		
        public static IInputReader Joy2Testing() => new AirconsoleController(
                            "Joystick2Horizontal",
                            "Joystick2Vertical",
                            KeyCode.Joystick2Button0,
                            KeyCode.Joystick2Button1,
                            KeyCode.Joystick2Button2, 
                            KeyCode.Joystick2Button3);
                    
        public static IInputReader Joy2Testing(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify) => new JoyInput(xAxis,yAxis,interact,jump,tool, notify);
        
        public static IInputReader Joy3Testing() => new AirconsoleController(
                            "Joystick3Horizontal",
                            "Joystick3Vertical",
                            KeyCode.Joystick3Button0,
                            KeyCode.Joystick3Button1,
                            KeyCode.Joystick3Button2, 
                            KeyCode.Joystick3Button3);
                    
        public static IInputReader Joy3Testing(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify) => new JoyInput(xAxis,yAxis,interact,jump,tool, notify);
        
        public static IInputReader Joy4Testing() => new AirconsoleController(
                            "Joystick4Horizontal",
                            "Joystick4Vertical",
                            KeyCode.Joystick4Button0,
                            KeyCode.Joystick4Button1,
                            KeyCode.Joystick4Button2, 
                            KeyCode.Joystick4Button3);
                    
        public static IInputReader Joy4Testing(string xAxis, string yAxis, KeyCode interact, KeyCode jump, KeyCode tool, KeyCode notify) => new JoyInput(xAxis,yAxis,interact,jump,tool, notify);

        public static IInputReader AirTest() => new AirconsoleController(
                            "Joystick4Horizontal",
                            "Joystick4Vertical",
                            KeyCode.Joystick1Button0,
                            KeyCode.Joystick1Button1,
                            KeyCode.Joystick1Button2,
                            KeyCode.Joystick1Button3);

    }
}