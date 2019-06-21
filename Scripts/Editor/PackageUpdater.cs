using UnityEngine;
using UnityEditor;
using System.IO;

public class PackageUpdater : EditorWindow
{
    [MenuItem("File/Update Packages")]
    static void UpdatePackages()
    {
        if (!EditorUtility.DisplayDialog("WARNING", $"You are about to update ALL packages.", "Okay", "Cancel"))
            return;

        DirectoryInfo pathToManifest = new DirectoryInfo($"{Application.dataPath}/../Packages/manifest.json");
        string manifestData = File.ReadAllText(pathToManifest.FullName);
        Debug.Log(manifestData.Contains("\"lock\""));
        manifestData = manifestData.Replace("\"lock\"", "\"trash\"");//TODO understand why
        Debug.Log(manifestData);
        File.WriteAllText(pathToManifest.FullName, manifestData);
    }

    [MenuItem("File/Update Packages", true)]
    static bool UpdatePackagesCheck(MenuCommand menuCommand)
    {
        return File.Exists($"{Application.dataPath}/../Packages/manifest.json");
    }
}