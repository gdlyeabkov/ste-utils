using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class ZekGeneratorWindow : EditorWindow
{

    public string scriptName = "";

    public static void Init()
    {
        ZekGeneratorWindow window = ScriptableObject.CreateInstance<ZekGeneratorWindow>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    public void OnGUI()
    {
        EditorGUILayout.LabelField("Создать новый тип зека?", EditorStyles.wordWrappedLabel);
        GUILayout.Space(25);
        scriptName = GUILayout.TextField(scriptName);
        GUILayout.Space(25);
        if (GUILayout.Button("Создать"))
        {
            CreateZekBehaviour();
        }
        else if (GUILayout.Button("Отмена"))
        {
            this.Close();
        }
    }

    public void CreateZekBehaviour ()
    {
        string behaviourTemplatePath = "Assets/Scripts/Templates/ZekTemplateBehaviour.cs";
        string newZekBehaviourPath = "Assets/Scripts/Zek.cs";
        string renamedNewZekBehaviourName = scriptName;
        string defaultBehaviourName = "ZekTemplateBehaviour";
        bool isCreateOperationSuccess = AssetDatabase.CopyAsset(behaviourTemplatePath, newZekBehaviourPath);
        if (isCreateOperationSuccess)
        {
            string tempBehaviourContent = File.ReadAllText(newZekBehaviourPath);
            string replacedBehaviourContent = tempBehaviourContent.Replace(defaultBehaviourName, scriptName);
            File.WriteAllText(newZekBehaviourPath, replacedBehaviourContent);
            string renamedResult = AssetDatabase.RenameAsset(newZekBehaviourPath, scriptName);
            bool isRenameOperationFailed = renamedResult.Length <= 0;
            if (isRenameOperationFailed)
            {
                ShowErrors("Не удается назвать сценарий");
            }
            this.Close();
        }
        else
        {
            ShowErrors("Не удается создать сценарий");
        }
    }

    public void ShowErrors(string errors)
    {
        EditorUtility.DisplayDialog("Обнаружены ошибки", errors, "Закрыть");
    }

}
