-- ����Accountԭ��
Account = {balance = 0,   -- �˻������=0
	withdraw = function (self, v)
					self.balance = self.balance - v
				end
}

function Account:deposit(v)   -- ��Ǯ
	self.balance = self.balance + v
end

function Account:new(o)		-- function Account.new(self)
	o = o or {}
	setmetatable(o, self)
	self.__index = self
	return o
end

-- ����SpecialAccount�̳�Accountԭ�ͣ��������˻����ö��limit=1000
SpecialAccount = Account:new({limit = 1000})

-- ��дwithdraw����
function SpecialAccount:withdraw(v)
	print("SA.withdraw "..v)
	local b = self.balance - v
	if b < -self.limit then error "����" end
	self.balance = b
end


local obj = SpecialAccount:new()
print(obj.limit)


