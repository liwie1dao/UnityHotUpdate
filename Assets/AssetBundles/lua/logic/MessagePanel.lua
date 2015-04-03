require "common/functions"

local this;
local gameObject;
MessagePanel = {};

--启动事件--发送登录请求--
function MessagePanel.Start()
	this = MessagePanel;
	gameObject = find("MessagePanel");
	warn("Start lua--->>"..gameObject.name);

	local panel = gameObject:GetComponent('BaseLua');
	-- panel.depth = 10;	--设置纵深--

	panel:AddClick('Button')
end

--单击事件--
function MessagePanel.OnClick()
	destroy(gameObject);
end

