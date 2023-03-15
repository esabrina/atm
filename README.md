# ATM withdrawal

**Introduction:**

The .NET solution to simulate a bank ATM withdrawal. 

Requirements: 
 - Deliver the least number of banknotes; 
 - You can only withdraw the requested amount with the available banknotes; 
 - Infinite customer balance; 
 - Finite amount of banknotes; 
 - Available banknotes of R$100,00; R$50,00; R$20,00 and R$10,00 
 - You can make withdrawals until banknotes is over
 
 Result examples: 
 - Withdrawal Amount: R$30.00 - Expected Result: Entregar 1 nota de R$20,00 e 1 nota de R$10,00. 
 - Withdrawal amount: R$60.00 - Expected Result: Entregar 1 nota de R$50,00 e 1 nota de R$10,00. 
 - Withdrawal amount: R$80.00 - Expected Result: Entregar 1 nota de R$50,00, 1 nota de R$20,00 bill e 1 nota de R$10,00.



## How to use it 

 - Run console application
 - The amount of banknotes available on ATM will be displayed
 - Type a withdrawal amount (integer value) and press **Enter**
 - Type **exit** to leave application
 
 Example:
 
	```Console
	=> ATM started with:
	3 notes of R$10
	3 notes of R$20
	3 notes of R$50
	3 notes of R$100

	=> Enter withdraw amount (integer) or type 'exit' to leave:
	130
	Entregar 1 notas de R$10
	Entregar 1 notas de R$20
	Entregar 1 notas de R$100

	=> Enter withdraw amount (integer) or type 'exit' to leave:
	70
	Entregar 1 notas de R$20
	Entregar 1 notas de R$50

	=> Enter withdraw amount (integer) or type 'exit' to leave:
	exit
	ATM finished.
	````
 

