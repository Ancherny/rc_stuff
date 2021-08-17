-- Performs audio feedback of an input channel
-- Can be turned on and off by a second channel (switch) when in given range

local inputs =
{
    { "Input", SOURCE },
    { "Switch", SOURCE },
    { "SwMin", VALUE, -1024, 1024, 0 },
    { "SwMax", VALUE, -1024, 1024, 1024 },
}
local outputs = {}

local function run(inp,sw,sw_min,sw_max)
    if sw < sw_min or sw > sw_max then
        return
    end

    norm_inp = (inp + 1024) / 2048
    if norm_inp > 0.05 then
        freq = 50 + 500 * norm_inp
        playTone(freq, 100, 0, PLAY_BACKGROUND)
    end
    return
end

return { input=inputs, output=outputs, run=run }
