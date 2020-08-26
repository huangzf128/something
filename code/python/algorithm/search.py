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
    for blockNo in range(0, m, m):
        if (ary[blockNo] == target):
            return blockNo
        elif (ary[blockNo] > target):
            place = lineSearch(ary[blockNo - m + 1: blockNo - 1], target)
            return (place if place == -1 else (blockNo - m + 1) + place)
    else:
        place = lineSearch(ary[blockNo + 1:], target)
        return (place if place == -1 else (blockNo + 1) + place)

# need sort
def interpolation(ary, target, start, end):
    if (target < ary[start] or target > ary[end]):
        return -1

    index = start + math.floor((end - start) * ((target - ary[start]) / (ary[end] - ary[start])))
    if (ary[index] == target):
        return index
    elif (ary[index] < target):
        start = index
    else:
        end = index

    if (start == end):
        return -1
    else:
        return interpolation(ary, target, start, end)


if __name__ == "__main__":
    print("dfs")
    ary = [1, 2, 3, 8, 10, 15]

    # print(lineSearch(ary, "2"))
    # print(binarySearch(ary, "3", 0, len(ary) - 1))
    # print(jumpSearch(ary, "11"))
    print(interpolation(ary, 16, 0, len(ary) - 1))
