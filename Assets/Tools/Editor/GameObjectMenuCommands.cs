using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public static class GameObjectMenuCommands
{
    [MenuItem("GameObject/UI/Custom Button", priority = 2030)]
    private static void CreateCustomButton() => Object.Instantiate(Resources.Load("CustomButton"), Selection.activeGameObject.transform).name = "CustomButton";

    [MenuItem("GameObject/UI/Custom Button", true)]
    private static bool CreateCustomButtonValidation() => Selection.activeGameObject != null && Selection.activeGameObject.GetComponent<RectTransform>() != null;
}