using UnityEngine;
using UnityEditor;
using System.IO;

namespace PackageTools
{
	public class PackageUpdater : EditorWindow
	{
		[MenuItem("File/Package Tools/Update Packages")]
		static void UpdatePackages()
		{
			if (!EditorUtility.DisplayDialog("WARNING", $"You are about to update ALL packages.", "Okay", "Cancel"))
				return;

			DirectoryInfo pathToManifest = new DirectoryInfo($"{Application.dataPath}/../Packages/manifest.json");
			string manifestData = File.ReadAllText(pathToManifest.FullName);
			Debug.Log(manifestData.Contains("\"lock\""));
			manifestData = manifestData.Replace("\"lock\"", "\"trash\"");
			Debug.Log(manifestData);
			File.WriteAllText(pathToManifest.FullName, manifestData);
		}

		//Can update only if the manifest is found
		[MenuItem("File/Package Tools/Update Packages", true)]
		static bool UpdatePackagesCheck(MenuCommand menuCommand)
		{
			return File.Exists($"{Application.dataPath}/../Packages/manifest.json");
		}
	}
}