using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZekGenerator : ScriptableWizard
{
    
    [MenuItem("STE Расширения/Создать зека")]
    static void GenerateZek()
    {
        ZekGeneratorWindow.Init();
    }

}
