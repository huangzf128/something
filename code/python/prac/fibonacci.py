# print fibonacci

def printFibonacci(n1, n2):
    sum = n1 + n2
    if (n2 > 100):
        return
    else:
        if (n1 == 0):
            print(n1)

        print(sum)
        printFibonacci(n2, sum)

printFibonacci(0, 1)
