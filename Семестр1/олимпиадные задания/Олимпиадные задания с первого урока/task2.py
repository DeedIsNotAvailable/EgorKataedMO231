k = 5
l = 10
p = 7
n = int(input())

summ1 = 0 # способ с циклом
summ2 = 0 # способ с формулой

for i in range(n):
    summ1 += 2 * p
    summ1 += 2 * k
    summ1 += 2 * l
    summ1 += (n - 1) * l

summ2 = n*((2 * p) + (2 * k) + (2 * l)) + n*((n-1) * l)

print(summ1)
print(summ2)