import math

def lineSearch(ary, target):
    for i, a in enumerate(ary, 0):
        if(a == target):
            return i
            break
    else:
        return -1

# need sort
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

# need sort
def jumpSearch(ary, target):
    m = math.floor(math.sqrt(len(ary)))
    curPlace = 0
    for i in range(m):
        curPlace = i
        for blockNo in range(m):
            curPlace += (blockNo * m)
            if (ary[curPlace] == target):
                return curPlace
            elif (ary[curPlace] < target):
                break
            else:
                if (blockNo == m - 1):
                    return lineSearch(ary[curPlace + 1:], target)
                else:
                    return lineSearch(ary[curPlace + 1: (blockNo + 1) * m])


if __name__ == "__main__":
    ary = ["1", "2", "3", "4", "5"]

    # lineSearch(ary, "2")
#    print(binarySearch(ary, "3", 0, len(ary)))
