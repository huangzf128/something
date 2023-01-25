
def mergeSort(list):
    split(list, 0, len(list) - 1)
    print(list)


def split(list, left, right):
    if (left < right):
        mid = (left + right) // 2
        split(list, left, mid)
        split(list, mid + 1, right)
        merge(list, left, mid, right)


def merge(list, left, mid, right):
    temp = []
    leftIdx = left
    rightIdx = mid + 1
    while (leftIdx <= mid and rightIdx <= right):
        if list[leftIdx] < list[rightIdx]:
            temp.append(list[leftIdx])
            leftIdx += 1
        elif list[leftIdx] > list[rightIdx]:
            temp.append(list[rightIdx])
            rightIdx += 1
        else:
            temp.append(list[leftIdx])
            leftIdx += 1
            temp.append(list[rightIdx])
            rightIdx += 1

    # if rightIdx <= right:
    #     for i in range(rightIdx, right + 1):
    #         temp.append(list[i])
    if leftIdx <= mid:
        for i in range(leftIdx, mid + 1):
            temp.append(list[i])

    for i in range(0, len(temp)):
        list[i + left] = temp[i]


mergeSort([9, 8, 7, 6, 5, 4, 3, 2, 1])

# mergeSort([2, 1, 4, 3])
