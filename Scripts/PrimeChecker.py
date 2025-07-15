 Program is designed to find out if a number that the user gives it is prime or not


Start the program

Ask the user to type a number
Save that number as 'number'

If the number is less than 2:
    Say “Numbers smaller than 2 are not prime.”
    Stop the program

If the number can be divided by 2 with no leftovers:
    Say “This number is not prime because it’s even.”
Else:
    Set 'is_prime' to true
    Divide the number by 2 and save it as 'half'

    Say “Half of that number is [half], now checking...”

    Go through all odd numbers from 3 up to half:
        Try dividing the number by each one
        If it divides perfectly (no leftovers):
            Say “This number is not prime — it divides evenly by [that number].”
            Set 'is_prime' to false
            Stop checking

    If 'is_prime' is still true:
        Say “Yep, this number is prime!”

End program








number = int(input("Enter a number you would like to check if it is prime: "))


if number % 2 == 0:
	print("This number isn't a prime number because it is even")
else:
	is_prime = True
	half = number/2

	print(f"Half of {number} is {half}")

	for i in range(3, int(half) + 1, 2): 
		print(f"Dividing by {i}")
		if number % i == 0:
			print(f"This number isn't a prime number as it is divisible by {i}")
			is_prime = False
			break

	if is_prime:
		print("This number is a Prime Number!")

