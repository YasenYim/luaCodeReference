-- 定义Account原型

Account = {balance = 0,   -- 账户，余额=0
	withdraw = function (self, v)
					self.balance = self.balance - v
				end
}

function Account:deposit(v)   -- 存钱
	self.balance = self.balance + v
end

-- 一个特殊的表mt，它只有一个key  __index = 原型
local mt = {__index = Account}

obj = {}
setmetatable(obj, mt)   -- 把mt作为obj的元表
-- 这里，obj就变成了Account的副本


-- 测试创建对象
obj:deposit(200)
obj:withdraw(100)
print(obj.balance)

obj:deposit(1)
obj:withdraw(2)
print(obj.balance)

print("---------------------")
local accounts = {}

for i=1,10 do 
	accounts[i] = {}
	setmetatable(accounts[i], mt)
end

for i=1,10 do 
	accounts[i]:deposit(i * 10)
end

for i=1,10 do 
	print(accounts[i].balance)
end



