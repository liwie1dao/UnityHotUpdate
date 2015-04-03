using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ResourceManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LoadAsset", LoadAsset),
		new LuaMethod("New", _CreateResourceManager),
		new LuaMethod("GetClassType", GetClassType),
		new LuaMethod("__eq", Lua_Eq),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateResourceManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ResourceManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ResourceManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "ResourceManager", typeof(ResourceManager), regs, fields, typeof(UnityEngine.MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ResourceManager obj = LuaScriptMgr.GetNetObject<ResourceManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		GameObject o = obj.LoadAsset(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetVarObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetVarObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

