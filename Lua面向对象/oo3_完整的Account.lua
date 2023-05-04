-- 面向对象

Account = {balance = 0,   -- 账户，余额=0

	withdraw = function (self, v)
					self.balance = self.balance - v
				end
}

function Account:deposit(v)   -- 存钱
	self.balance = self.balance + v
end

Account:deposit(200)
Account:withdraw(100)

print(Account.balance)

