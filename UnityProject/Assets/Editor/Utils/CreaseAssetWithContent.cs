using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.Serialization;

namespace Editor.Utils
{
    public class CreateAssetWithContent : EndNameEditAction
    {
        public string fileContent;
        public string className;

        
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            className = Path.GetFileNameWithoutExtension(pathName);
            
            resourceFile = CreateAssetWithContent.PreprocessClassName(pathName,fileContent);
            resourceFile = CreateAssetWithContent.SetLineEndings(resourceFile, EditorSettings.lineEndingsForNewScripts);

            resourceFile = CreateAssetWithContent.PreprocessClassName(className,resourceFile);

            resourceFile = CreateAssetWithContent.PreprocessModName(pathName,resourceFile);

            CreateScriptAssetWithContent(pathName, resourceFile);
        }

        UnityEngine.Object CreateScriptAssetWithContent(string pathName, string templateContent)
        {
            templateContent = SetLineEndings(templateContent, EditorSettings.lineEndingsForNewScripts);
            File.WriteAllText(Path.GetFullPath(pathName), templateContent);
            AssetDatabase.ImportAsset(pathName);
            return AssetDatabase.LoadAssetAtPath(pathName, typeof (UnityEngine.Object));
        }
        
        public static string SetLineEndings(string content, LineEndingsMode lineEndingsMode)
        {
            string replacement;
            switch (lineEndingsMode)
            {
                case LineEndingsMode.OSNative:
                    replacement = Application.platform != RuntimePlatform.WindowsEditor ? "\n" : "\r\n";
                    break;
                case LineEndingsMode.Unix:
                    replacement = "\n";
                    break;
                case LineEndingsMode.Windows:
                    replacement = "\r\n";
                    break;
                default:
                    replacement = "\n";
                    break;
            }
            content = Regex.Replace(content, "\\r\\n?|\\n", replacement);
            return content;
        }
        
        public static string PreprocessClassName(string className, string resourceContent)
        {
            string str1 = resourceContent.Replace("#NAME#", Path.GetFileNameWithoutExtension(className));
            return str1;
        }
        
        public static string PreprocessModName(string modName, string resourceContent)
        {
            modName = modName.Replace(" ","");
            string str1 = resourceContent.Replace("#MODNAME#", Path.GetFileNameWithoutExtension(modName));
            return str1;
        }
    }
}