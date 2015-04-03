using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ResourceManager : MonoBehaviour {
    private string[] m_Variants = { };
    private AssetBundleManifest manifest;
    private AssetBundle shared, assetbundle;
    private Dictionary<string, AssetBundle> bundles;

    void Awake() {
        Initialize();
    }
	
    /// <summary>
    /// 初始化
    /// </summary>
    void Initialize() {
        byte[] stream = null;
        string uri = string.Empty;
        bundles = new Dictionary<string, AssetBundle>();
        uri = Util.DataPath + Const.AssetDirname;
        stream = File.ReadAllBytes(uri);
        assetbundle = AssetBundle.CreateFromMemoryImmediate(stream);
        manifest = assetbundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        ioo.gameManager.OnResourceInited();    //资源初始化完成，回调游戏管理器，执行后续操作 
    }

    /// <summary>
    /// 载入素材
    /// </summary>
    public GameObject LoadAsset(string abname, string assetname) {
        abname = abname.ToLower();
        AssetBundle bundle = LoadAssetBundle(abname);
        return bundle.LoadAsset<GameObject>(assetname);
    }

    /// <summary>
    /// 载入AssetBundle
    /// </summary>
    /// <param name="abname"></param>
    /// <returns></returns>
    AssetBundle LoadAssetBundle(string abname) {
        if (!abname.EndsWith(Const.ExtName)) {
            abname += Const.ExtName;
        }
        AssetBundle bundle = null;
        if (!bundles.ContainsKey(abname)) {
            byte[] stream = null;
            string uri = Util.DataPath + abname;
            Debug.LogWarning("LoadFile::>> " + uri);
            LoadDependencies(abname);

            stream = File.ReadAllBytes(uri);
            bundle = AssetBundle.CreateFromMemoryImmediate(stream); //关联数据的素材绑定
            bundles.Add(abname, bundle);
        } else {
            bundles.TryGetValue(abname, out bundle);
        }
        return bundle;
    }

    /// <summary>
    /// 载入依赖
    /// </summary>
    /// <param name="name"></param>
    void LoadDependencies(string name) {
        if (manifest == null) {
            Debug.LogError("Please initialize AssetBundleManifest by calling AssetBundleManager.Initialize()");
            return;
        }
        // Get dependecies from the AssetBundleManifest object..
        string[] dependencies = manifest.GetAllDependencies(name);
        if (dependencies.Length == 0) return;

        for (int i = 0; i < dependencies.Length; i++)
            dependencies[i] = RemapVariantName(dependencies[i]);

        // Record and load all dependencies.
        for (int i = 0; i < dependencies.Length; i++) {
            LoadAssetBundle(dependencies[i]);
        }
    }

    // Remaps the asset bundle name to the best fitting asset bundle variant.
    string RemapVariantName(string assetBundleName) {
        string[] bundlesWithVariant = manifest.GetAllAssetBundlesWithVariant();

        // If the asset bundle doesn't have variant, simply return.
        if (System.Array.IndexOf(bundlesWithVariant, assetBundleName) < 0)
            return assetBundleName;

        string[] split = assetBundleName.Split('.');

        int bestFit = int.MaxValue;
        int bestFitIndex = -1;
        // Loop all the assetBundles with variant to find the best fit variant assetBundle.
        for (int i = 0; i < bundlesWithVariant.Length; i++) {
            string[] curSplit = bundlesWithVariant[i].Split('.');
            if (curSplit[0] != split[0])
                continue;

            int found = System.Array.IndexOf(m_Variants, curSplit[1]);
            if (found != -1 && found < bestFit) {
                bestFit = found;
                bestFitIndex = i;
            }
        }
        if (bestFitIndex != -1)
            return bundlesWithVariant[bestFitIndex];
        else
            return assetBundleName;
    }

    /// <summary>
    /// 销毁资源
    /// </summary>
    void OnDestroy() {
        if (shared != null) shared.Unload(true);
        if (manifest != null) manifest = null;
        Debug.Log("~ResourceManager was destroy!");
    }
}
