-- �������

Account = {balance = 0,   -- �˻������=0

	withdraw = function (self, v)
					self.balance = self.balance - v
				end
}

function Account:deposit(v)   -- ��Ǯ
	self.balance = self.balance + v
end

Account:deposit(200)
Account:withdraw(100)

print(Account.balance)

