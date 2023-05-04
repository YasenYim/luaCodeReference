-- 注意：在交互式环境中执行：
-- p1 = dofile("test_env.lua")
-- p2 = dofile("test_env.lua")
-- 即可创建两个独立的“对象” p1 和 p2

local player = {}
setmetatable(player, {__index=_ENV})
_ENV = player

hp = 10
atk = 1

function CostHp(n)
    hp = hp -n
end

print(math.sin(math.pi))

return player
