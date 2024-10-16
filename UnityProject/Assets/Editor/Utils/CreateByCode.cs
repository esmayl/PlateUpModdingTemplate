using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Editor.Utils;
using UnityEditor;
using UnityEditor.Compilation;
using UnityEditor.VersionControl;
using UnityEngine;
using Assembly = UnityEditor.Compilation.Assembly;
using Task = System.Threading.Tasks.Task;

public static class CreateByCode
{
    static string templateDirectiory = "Templates/"; // Root is one level higher then Assets
    
    [MenuItem("PlateUp!/Create new item by code")]
    public static void CreateItem()
    {
        Texture2D fileIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        
        CreateAssetWithContent instance = ScriptableObject.CreateInstance<CreateAssetWithContent>();
        string resourceContent = File.ReadAllText(templateDirectiory+"Item.cs");
        instance.fileContent = resourceContent;
        
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, instance, "NewItem.cs", fileIcon, (string) null);
    }

    [MenuItem("PlateUp!/Create new mod file by code")]
    public static void CreateMod()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templateDirectiory+"Mod.cs", "Mod.cs");
    }
    
    [MenuItem("PlateUp!/Create new process by code")]
    public static void CreateProcess()
    {
        Texture2D fileIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        
        CreateAssetWithContent instance = ScriptableObject.CreateInstance<CreateAssetWithContent>();
        string resourceContent = File.ReadAllText(templateDirectiory+"Process.cs");
        instance.fileContent = resourceContent;
        
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, instance, "NewProcess.cs", fileIcon, (string) null);
    }
    
    [MenuItem("PlateUp!/Create a new dish by code")]
    public static void CreateDish()
    {
        Texture2D fileIcon = EditorGUIUtility.IconContent("cs Script Icon").image as Texture2D;
        
        CreateAssetWithContent instance = ScriptableObject.CreateInstance<CreateAssetWithContent>();
        string resourceContent = File.ReadAllText(templateDirectiory+"Dish.cs");
        instance.fileContent = resourceContent;
        
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0, instance, "NewDish.cs", fileIcon, (string) null);
    }

    [MenuItem("PlateUp!/Create new reference library by code")]
    public static void CreateReferenceLibrary()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templateDirectiory+"ReferenceLibrary.cs", "ReferenceLibrary.cs");
    }
}
