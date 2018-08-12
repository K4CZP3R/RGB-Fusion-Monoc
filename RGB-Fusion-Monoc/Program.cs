using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


//By K4CZP3R, @2018
namespace RGB_Fusion_Monoc
{
    class Program
    {

        public class GLedAPI
        {
            [DllImport("GLedApi.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
            public static extern uint dllexp_GetSdkVersion(StringBuilder lpBuf, int bufSize);
            public uint _GetSdkVersion(StringBuilder lpBuf, int bufSize) => dllexp_GetSdkVersion(lpBuf, bufSize);
            public static string GetSdkVersion()
            {
                int length = 16;
                StringBuilder buffer = new StringBuilder(length);
                GLedAPI.dllexp_GetSdkVersion(buffer, length);
                return buffer.ToString();
            }

            [DllImport("GLedApi.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern uint dllexp_InitAPI();
            public static uint _InitAPI() => dllexp_InitAPI();
            public static uint InitAPI()
            {
                uint returns = _InitAPI();
                if(returns != 0)
                {
                    ConsoleColor def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if(returns == 4317)
                    {
                        Console.WriteLine("InitAPI: are you sure dlls are in the same dir as exe?", returns);
                    }
                    else
                    {
                        Console.WriteLine("InitAPI: Program may not work correctly, expected '0' not '{0}'", returns);
                    }
                    Console.ForegroundColor = def;
                    
                }
                return returns;
            }

            [DllImport("GLedApi.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int dllexp_MonocLedCtrlSupport();
            public static int _MonocLedCtrlSupport() => dllexp_MonocLedCtrlSupport();
            public static int MonocLedCtrlSupport()
            {
                int returns = GLedAPI.dllexp_MonocLedCtrlSupport();
                if(returns != 3)
                {
                    ConsoleColor def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("MonocLedCtrlSupport: Program may not work correctly, expected '3' not '{0}'", returns);
                    Console.ForegroundColor = def;
                }
                return returns;
            }

            [DllImport("GLedApi.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern int dllexp_GetRGBPinType();
            public static int _GetRGBPinType() => dllexp_GetRGBPinType();
            public static int GetRGBPinType()
            {
                int returns = GLedAPI.dllexp_GetRGBPinType();
                if(returns != 1)
                {
                    ConsoleColor def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GetRGBPinType: Program may not work correctly, expected '1' not '{0}'", returns);
                    Console.ForegroundColor = def;
                }
                return returns;
            }

            [DllImport("GLedApi.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern bool dllexp_SetMonocLedMode(int mnoLedMode);
            public static bool _SetMonocLedMode(int mnoLedMode) => dllexp_SetMonocLedMode(mnoLedMode);
            public static bool SetMonocLedMode(int mnoLedMode)
            {
                bool returns = _SetMonocLedMode(mnoLedMode);
                if(returns != true)
                {
                    ConsoleColor def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SetMonocLedMode: Program may not work correctly, expected 'true' not '{0}'", returns);
                    Console.ForegroundColor = def;
                }
                return returns;
            }

            [DllImport("GLedApi.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern uint dllexp_RGBPin_Type1(int pin1, int pin2, int pin3);
            public static uint _RGBPin_Type1(int pin1, int pin2, int pin3) => dllexp_RGBPin_Type1(pin1, pin2, pin3);
            public static uint RGBPin_Type1(int[] pins)
            {
                uint returns = GLedAPI._RGBPin_Type1(pins[0], pins[1], pins[2]);
                if (returns != 0)
                {
                    ConsoleColor def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (returns == 4317)
                    {
                        Console.WriteLine("RGBPin_Type1: are you sure dlls are in the same dir as exe?", returns);
                    }
                    else
                    {
                        Console.WriteLine("RGBPin_Type1: Program may not work correctly, expected '0' not '{0}'", returns);
                    }
                    Console.ForegroundColor = def;
                }
                return returns;
            }
        }
        static void Main(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("3 Args needed! eg. '1 1 0' [r, g, b] will set red and green on");
                System.Environment.Exit(0);
            }
            DisplayFunc(GLedAPI.GetSdkVersion(), "GetSdkVersion()");
            DisplayFunc(GLedAPI.InitAPI(), "InitAPI()");
            DisplayFunc(GLedAPI.MonocLedCtrlSupport(), "MonocLedCtrlSupport()");
            DisplayFunc(GLedAPI.GetRGBPinType(), "GetRGBPinType()");

            int[] leds = { int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]) };
            DisplayFunc(GLedAPI.SetMonocLedMode(2), "SetMonocLedMode()");
            DisplayFunc(GLedAPI.RGBPin_Type1(leds), "RGBPin_Type1(leds)");
            Console.WriteLine("Done!");
            Environment.Exit(0);

        }
        static void DisplayFunc(object function_returned, string name)
        {
            Console.WriteLine("Call: 'dllexp_{0}' returns '{1}'", name, function_returned.ToString());
        }
    }
}
