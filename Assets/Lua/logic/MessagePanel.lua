require "common/functions"

local this;
local gameObject;
MessagePanel = {};

--启动事件--发送登录请求--
function MessagePanel.Start()
	this = MessagePanel;
	gameObject = find("MessagePanel");
	warn("Start lua--->>"..gameObject.name);

	local panel = gameObject:GetComponent('UIPanel');
	panel.depth = 10;	--设置纵深--

	local Button = find('Button');
	UIEventListener.Get(Button).onClick = LuaHelper.VoidDelegate(this.OnClick);
end

--单击事件--
function MessagePanel.OnClick()
	destroy(gameObject);
end

