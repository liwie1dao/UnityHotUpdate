﻿本工程基于Unity 5.0f4 + uLua 1.08 + tolua c#构建

//-------------2015-04-20-------------
(1)集成了tolua #1.9.1。
(2)资源加载使用了异步多线程加载。

//-------------2015-04-11---------------
(1)将框架0.2.7f2移植到Unity GUI环境下。

//-------------2015-04-03---------------
(1)将框架0.2.7f1移植到Unity GUI环境下。

//-------------2015-03-26---------------
(1)将框架0.2.5f4移植到Unity GUI环境下。

//-------------2015-03-15---------------
(1)将框架移植到Unity GUI环境下。

//-------------2015-02-14---------------
(1)添加nlua兼容模式，可选择ulua模式或nlua模式。

//-------------2015-02-11---------------
(1)添加了ios armv7s arm64平台支持。
(2)luajit使用了最新版本2.1。
(3)修复了iPhone5s以上设备不能直接运行的路径bug。

//-------------2015-01-18---------------
(1)增加了简单的解包功能。
(2)直接运行到真机（安卓+ios），而不在需要copy资源到真机存储卡。

//-------------2015-01-08---------------
(1)集成最新版tolua c# 1.7.2版，修复某些生成Wrap类错误BUG。
(2)修复了手动copy到ios真机上FileStream读取权限失败的BUG。
(3)清除函数缓存增加了删除Wrap文件缓存功能。

//-------------2014-12-31---------------
(1)集成最新版tolua c# 1.7.1版

//-------------2014-12-18---------------
(1)添加的可加密的sqlite功能的工具
(2)添加了sqlitekit函数库。
(3)删除了LuaWrap在U3D4.6版本之前老版本打开错误提示问题。
(4)添加了Debuger.dll,以后可使用Debuger.DebugXXX函数，而不会跳转到其函数体内。

//-------------2014-11-29---------------
(1)集成tolua c# 2.03版本
(2)增加了Class.lua自定义类
(3)修改了tolua c#中生成自定义类与U3D类合并函数

//-------------2014-10-10---------------
(1)集成tolua c# 1.2版本

//-------------2014-09-27---------------
(1)添加了一个基于supersocket的服务器端框架。
(2)集成了网络模块，并且通过lua发送消息给，返回echo流程已完成。
服务器框架程序:SimpleFramework\Server\Server\bin\Debug\SuperSocket.SocketService.exe
服务器配置文件:同上目录\SuperSocket.SocketService.exe.config
PS:运行服务器程序，需要.Net(windows)/Mono(linux) 4.0以上版本

//-------------2014-09-26---------------
(1)集成了UIWrapGrid.cs，100个滚动列表项不卡（亲测2000不卡）。
(2)因同学需求，添加了弹出面板。

//-------------2014-09-25---------------
(1)集成了阿萌的tolua c#版插件.
(2)集成了UnityVS调试插件

