using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeyValue {
    public string key;
    public string value;
    public KeyValue(string key, string value) {
        this.key = key; this.value = value;
    }
}

public class PanelManager : MonoBehaviour {
    private Transform parent;
    private static Queue<KeyValue> events = new Queue<KeyValue>();

    Transform Parent {
        get {
            if (parent == null) {
                parent = ioo.guiCamera;
            }
            return parent;
        }
    }

    /// <summary>
    /// 创建面板，请求资源管理器
    /// </summary>
    /// <param name="type"></param>
    public void CreatePanel(string name) {
        string assetName = name + "Panel";
        GameObject prefab = ioo.resourceManager.LoadAsset(name, assetName);
        if (Parent.FindChild(name) != null || prefab == null) {
            return;
        }
        GameObject go = Instantiate(prefab) as GameObject;
        go.name = assetName;
        go.layer = LayerMask.NameToLayer("Default");
        go.transform.SetParent(Parent);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
        go.AddComponent<BaseLua>(); 

        Debug.LogWarning("CreatePanel::>> " + name + " " + prefab);
    }
}
