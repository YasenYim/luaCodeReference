local M = {}   -- 模块名称M

--创建一个新的复数
local function new(r, i)
	return {r=r,i=i}
end

M.new = new   --把函数”new”加到模块中

-- 常数 i
M.i = new(0, 1)		-- M.i 是一个表 {r=0, i=1}

function M.add(c1,c2)
	return new(c1.r+c2.r, c1.i+c2.i)
end

function M.sub(cl,c2)
	return new(cl.r-c2.r, cl.i-c2.i)
end

function M.mul(c1,c2)
	return new(cl.r*c2.r-c1.i*c2.i, cl.r*c2.i + c1.i*c2.r)
end

local function inv(c)		-- 相当于私有函数
	local n = c.r^2 + c.i^2
	return new(c.r/n, - c.i/n)
end

function M.div(c1, c2)
	return M.mul(c1, inv(c2))
end

function M.tostring(c)
	return string.format("(%g, %g)", c.r, c.i)
end

return M       --返回M，重要
