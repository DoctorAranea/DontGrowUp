using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GameMenu : EditorWindow
{
    [MenuItem("Game/Take screenshot")]
    public static void TakeScreenshot()
    {
        string path = "Screenshots";
        Directory.CreateDirectory(path);

        int i = 0;
        while (File.Exists($"{path}/{i}.png"))
            i++;
        ScreenCapture.CaptureScreenshot($"{path}/{i}.png");
    }
}
