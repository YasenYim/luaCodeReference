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

-- 定义SpecialAccount继承Account原型，它具有账户信用额度limit=1000
SpecialAccount = Account:new({limit = 1000})

-- 重写withdraw方法
function SpecialAccount:withdraw(v)
	print("SA.withdraw "..v)
	local b = self.balance - v
	if b < -self.limit then error "余额不足" end
	self.balance = b
end


local obj = SpecialAccount:new()
print(obj.limit)


