-- 面向对象

Account = {balance = 0}   -- 账户，余额=0

function Account.withdraw(self, v)		-- 取款
	self.balance = self.balance - v
end


-- 取钱测试
print("余额:", Account.balance)
Account.withdraw(Account, 100)
print("余额:", Account.balance)

Account2 = {balance = 0}
Account2.withdraw = Account.withdraw

--Account = nil

-- 取钱测试
print("余额2:", Account2.balance)
Account2.withdraw(Account2, 5)
print("余额2:", Account2.balance)

--Account.withdraw(Account2, 10)
--print("余额2:", Account2.balance)

-- 用冒号隐藏self，不用再次重复

-- 取钱测试2
print("余额2:", Account2.balance)
Account2:withdraw(10)
print("余额2:", Account2.balance)

-- 注意：冒号: 是一个语法糖
-- 只要lua看到  表:函数(参数)
-- 自动替换为—— 表.函数(表，参数)


