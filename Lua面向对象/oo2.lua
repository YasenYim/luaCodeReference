-- �������

Account = {balance = 0}   -- �˻������=0

function Account.withdraw(self, v)		-- ȡ��
	self.balance = self.balance - v
end


-- ȡǮ����
print("���:", Account.balance)
Account.withdraw(Account, 100)
print("���:", Account.balance)

Account2 = {balance = 0}
Account2.withdraw = Account.withdraw

--Account = nil

-- ȡǮ����
print("���2:", Account2.balance)
Account2.withdraw(Account2, 5)
print("���2:", Account2.balance)

--Account.withdraw(Account2, 10)
--print("���2:", Account2.balance)

-- ��ð������self�������ٴ��ظ�

-- ȡǮ����2
print("���2:", Account2.balance)
Account2:withdraw(10)
print("���2:", Account2.balance)

-- ע�⣺ð��: ��һ���﷨��
-- ֻҪlua����  ��:����(����)
-- �Զ��滻Ϊ���� ��.����(������)


