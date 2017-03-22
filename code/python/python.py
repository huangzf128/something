def odd_or_even():
    for i in range(1, 6):
        if i % 2 != 0:
            print("{0} is odd".format(i))
        else:
            print("{0} is even".format(i))

if __name__ == "__main__":
    odd_or_even()

list = [1, 2, 3, 4]

print(list.count(2))