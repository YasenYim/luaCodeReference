-- 定义Account原型

Account = {balance = 0,   -- 账户，余额=0
	withdraw = function (self, v)
					self.balance = self.balance - v
				end
}

function Account:deposit(v)   -- 存钱
	self.balance = self.balance + v
end

function Account:new(o)		-- function Account.new(self)
	o = o or {}
	setmetatable(o, self)
	self.__index = self
	return o
end

-- 一个特殊的表mt，它只有一个key  __index = 原型
--local mt = {__index = Account}

--obj = {}
--setmetatable(obj, mt)   -- 把mt作为obj的元表
-- 这里，obj就变成了Account的副本

obj = Account:new()
-- 测试对象
obj:deposit(200)
obj:withdraw(100)
print(obj.balance)

obj2 = Account:new({balance = 999, hp =8, mp = 888})


