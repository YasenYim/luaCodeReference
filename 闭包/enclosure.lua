function F()
	local e = 1

	local G = function()
		print("in G", "e="..e)
		e = e+1
	end
	return G
end

function CreateObj()
	local t = {}
	local G = function()
		return t
	end
	return G
end

g = F()
g()
g()
g()
print("------------")

g2 = F()
g2()
g2()
g2()
g2()

print("------------")
g()
g()

obj_func = CreateObj()
local obj1 = obj_func()

