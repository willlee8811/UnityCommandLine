using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class BuildTool
{
    [MenuItem("BuildTool/Build")]
    private static void Build()
    {
        CustomizedCommandLine();

        string destinationPath = Path.Combine(_destinationPath, PlayerSettings.productName);
        destinationPath += GetExtension();

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, destinationPath, EditorUserBuildSettings.activeBuildTarget, BuildOptions.None);
    }


    private static string _destinationPath;
    private static void CustomizedCommandLine()
    {
        Dictionary<string, Action<string>> cmdActions = new Dictionary<string, Action<string>>
        {
            {
                "-destinationPath", delegate(string argument)
                {
                    _destinationPath = argument;
                }
            }
        };

        Action<string> actionCache;
        string[] cmdArguments = Environment.GetCommandLineArgs();

        for (int count = 0; count < cmdArguments.Length; count++)
        {
            if (cmdActions.ContainsKey(cmdArguments[count]))
            {
                actionCache = cmdActions[cmdArguments[count]];
                actionCache(cmdArguments[count + 1]);
            }
        }

        if (string.IsNullOrEmpty(_destinationPath))
        {
            _destinationPath = Path.GetDirectoryName(Application.dataPath);
        }
    }


    private static string GetExtension()
    {
        string extension = "";

        switch (EditorUserBuildSettings.activeBuildTarget)
        {
            case BuildTarget.StandaloneOSXIntel:
            case BuildTarget.StandaloneOSXIntel64:
            case BuildTarget.StandaloneOSXUniversal:
                extension = ".app";
                break;
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                extension = ".exe";
                break;
            case BuildTarget.Android:
                extension = ".apk";
                break;
            case BuildTarget.iOS:
                extension = ".ipa";
                break;
        }

        return extension;
    }

    [MenuItem("BuildTool/APKBuild")]
    public static void APKBuild()
    {
        BuildTarget buildTarget = BuildTarget.Android;
        // 切换到 Android 平台
        EditorUserBuildSettings.SwitchActiveBuildTarget(buildTarget);

        // keystore 路径, G:\keystore\one.keystore
        /*PlayerSettings.Android.keystoreName = "G:\\keystore\\one.keystore";
        // one.keystore 密码
        PlayerSettings.Android.keystorePass = "123456";

        // one.keystore 别名
        PlayerSettings.Android.keyaliasName = "bieming1";
        // 别名密码
        PlayerSettings.Android.keyaliasPass = "123456";*/

        List<string> levels = new List<string>();
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled) continue;
            // 获取有效的 Scene
            levels.Add(scene.path);
        }

        // 打包出 APK 名
        string apkName = string.Format("./{0}.apk", "Test");
        // 执行打包
        string res = BuildPipeline.BuildPlayer(levels.ToArray(), apkName, buildTarget, BuildOptions.None);

        AssetDatabase.Refresh();
    }
}