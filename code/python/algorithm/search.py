def lineSearch(ary, target):
    for i, a in enumerate(ary, 0):
        if(a == target):
            return i
            break
    else:
        return -1

def binarySearch(ary, target, start, end):
    index = (start + end) // 2
    if (ary[index] == target):
        return index
    elif (ary[index] < target):
        start = index
    else:
        end = index

    if (start == end):
        return -1
    else:
        return binarySearch(ary, target, start, end)

if __name__ == "__main__":
    ary = ["1", "2", "3", "4", "5"]

    # lineSearch(ary, "2")
    print(binarySearch(ary, "3", 0, len(ary)))
