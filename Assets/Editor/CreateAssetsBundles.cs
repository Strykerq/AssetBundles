using UnityEditor;

public class CreateAssetsBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void CreateBundels()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None,
            BuildTarget.StandaloneLinux64);
    }
}
