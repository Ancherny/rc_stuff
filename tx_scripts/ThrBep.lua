local inputs =
{
    { "Input", SOURCE },
}
local outputs = {}

local function run(i)
    norm_i = (i + 1024) / 2048
    if norm_i > 0.05 then
        freq = 50 + 500 * norm_i
        playTone(freq, 100, 0, PLAY_BACKGROUND)
    end
    return
end

return { input=inputs, output=outputs, run=run }
