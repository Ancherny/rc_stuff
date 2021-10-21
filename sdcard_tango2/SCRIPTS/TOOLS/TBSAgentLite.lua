-------------------------------------------------------------------------------
-- TBS Agent Lite 0.90
-- release date: 2021-02
-- author: JimB40
-------------------------------------------------------------------------------
local toolName = "TNS|TBS Agent Lite|TNE"
chdir('/SCRIPTS/TOOLS/TBSAGENTLITE')
local run = loadScript('loader.lua','bt')('0.9')
return {run=run}
