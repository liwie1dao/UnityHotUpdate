using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class BaseLua : MonoBehaviour {
    private string data = null;
    private bool initialize = false;
    private Transform trans = null;
    private LuaScriptMgr umgr = null;
    private Hashtable buttons = new Hashtable();

    protected LuaScriptMgr uluaMgr {
        get {
            if (umgr == null) {
                umgr = ioo.gameManager.uluaMgr;
            }
            return umgr;
        }
    }

    protected void Start() {
        trans = transform;
        CallMethod("Start");
    }

    protected void OnClick() {
        CallMethod("OnClick");
    }

    protected void OnClickEvent(GameObject go) {
        CallMethod("OnClick", go);
    }

    /// <summary>
    /// 添加单击事件
    /// </summary>
    public void AddClick(string button) {
        Transform to = trans.Find(button);
        if (to == null) return;
        GameObject go = to.gameObject;
        buttons.Add(button, go);
        go.GetComponent<Button>().onClick.AddListener(
            delegate() {
                OnClickEvent(go);
            }
        );
    }

    /// <summary>
    /// 移除单击事件
    /// </summary>
    public void RemoveClick(string button) {
        object o = buttons[button];
        if (o == null) return;
        GameObject go = o as GameObject;
    }

    /// <summary>
    /// 清除单击事件
    /// </summary>
    public void ClearClick() {
        foreach (DictionaryEntry de in buttons) {
            RemoveClick(de.Key.ToString());
        }
    }

    //-----------------------------------------------
    /// <summary>
    /// 执行Lua方法-无参数
    /// </summary>
    protected object[] CallMethod(string func) {
        if (uluaMgr == null) return null;
        string funcName = name + "." + func;
        funcName = funcName.Replace("(Clone)", "");
        return umgr.CallLuaFunction(funcName);
    }

    /// <summary>
    /// 执行Lua方法
    /// </summary>
    protected object[] CallMethod(string func, GameObject go) {
        if (uluaMgr == null) return null;
        string funcName = name + "." + func;
        funcName = funcName.Replace("(Clone)", "");
        return umgr.CallLuaFunction(funcName, go);
    }

    /// <summary>
    /// 执行Lua方法-Socket消息
    /// </summary>
    protected object[] CallMethod(string func, int key, ByteBuffer buffer) {
        if (uluaMgr == null) return null;
        string funcName = "Network." + func;
        funcName = funcName.Replace("(Clone)", "");
        return umgr.CallLuaFunction(funcName, key, buffer);
    }

    //-----------------------------------------------------------------
    protected void OnDestroy() {
        ClearClick();
        umgr = null; 
        Debug.Log("~" + name + " was destroy!");
    }
}