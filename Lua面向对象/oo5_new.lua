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

-- һ������ı�mt����ֻ��һ��key  __index = ԭ��
--local mt = {__index = Account}

--obj = {}
--setmetatable(obj, mt)   -- ��mt��Ϊobj��Ԫ��
-- ���obj�ͱ����Account�ĸ���

obj = Account:new()
-- ���Զ���
obj:deposit(200)
obj:withdraw(100)
print(obj.balance)

obj2 = Account:new({balance = 999, hp =8, mp = 888})


