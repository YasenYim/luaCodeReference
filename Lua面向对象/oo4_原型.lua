-- ����Accountԭ��

Account = {balance = 0,   -- �˻������=0
	withdraw = function (self, v)
					self.balance = self.balance - v
				end
}

function Account:deposit(v)   -- ��Ǯ
	self.balance = self.balance + v
end

-- һ������ı�mt����ֻ��һ��key  __index = ԭ��
local mt = {__index = Account}

obj = {}
setmetatable(obj, mt)   -- ��mt��Ϊobj��Ԫ��
-- ���obj�ͱ����Account�ĸ���


-- ���Դ�������
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



