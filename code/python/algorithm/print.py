# coding: utf-8
import random
import sys 
import io

sys.stdout = io.TextIOWrapper(sys.stdout.buffer, encoding='utf-8')
class TreeNode:
    parent_node = None
    l_child_node = None
    r_child_node = None
    level = 0    
    def __init__(self, value, level = 0):
        self.value = value
        self.level = level

class PrintElement:
    tree_node = None
    def __init__(self, coordinate, kind, node = None):
        self.coordinate = coordinate
        self.kind = kind    # 0: node, 1: /, 2: \, 3: -, 4: |
        self.tree_node = node

NODE = 0
SLASH = 1
BACKSLASH = 2
HORIZON = 3
VERTICAL = 4

SIZE_HORIZON = 10
SIZE_VERTICAL = 10
# -------------- make tree --------------------------

def make_rand_tree(root):
    if (root.level == 0):
        return
    root.l_child_node = TreeNode(random.randint(0, 99), root.level - 1)
    make_rand_tree(root.l_child_node)
    root.r_child_node = TreeNode(random.randint(0, 99), root.level - 1)
    make_rand_tree(root.r_child_node)

printer_info = []
def create_print_info(root, coord):
    global SIZE_VERTICAL, SIZE_HORIZON
    printer_info.append(PrintElement(coord, NODE, root))
    if (root.level == 0):
        SIZE_VERTICAL = max([SIZE_VERTICAL, coord[0]])
        SIZE_HORIZON = max([SIZE_HORIZON, coord[1] * 2 + 4])
        return

    # distance = int(5 * (2**(root.level - 1)) + (2**(root.level - 1)) - 1)
    distance = (3 + 1) * 2 ** (root.level - 2)
    distance = int(distance // 2)

    # print line
    y = 0
    if (distance >= 5):
        y = 5
        for i in range(1, distance):
            if (i <= 2):
                printer_info.append(PrintElement((coord[0] + i, coord[1] - i), SLASH))
                printer_info.append(PrintElement((coord[0] + i, coord[1] + i), BACKSLASH))
            elif (i == distance - 1):
                printer_info.append(PrintElement((coord[0] + 4, coord[1] - i), SLASH))
                printer_info.append(PrintElement((coord[0] + 4, coord[1] + i), BACKSLASH))
            else:
                printer_info.append(PrintElement((coord[0] + 3, coord[1] - i), HORIZON))
                printer_info.append(PrintElement((coord[0] + 3, coord[1] + i), HORIZON))
    else:
        y = distance + 1
        for i in range(1, distance + 1):
            printer_info.append(PrintElement((coord[0] + i, coord[1] - i), SLASH))
            printer_info.append(PrintElement((coord[0] + i, coord[1] + i), BACKSLASH))

    create_print_info(root.l_child_node, (coord[0] + y, coord[1] - distance))
    create_print_info(root.r_child_node, (coord[0] + y, coord[1] + distance))


def print_tree():
    board = []
    for _ in range(SIZE_VERTICAL + 1):
        r = []
        for _ in range(SIZE_HORIZON + 1):
            r.append("  ")
        board.append(r)

    for e in printer_info:
        if (e.kind == NODE):
            board[e.coordinate[0]][e.coordinate[1] + SIZE_HORIZON // 2] = str(e.tree_node.value).zfill(2)
        if (e.kind == SLASH):
            board[e.coordinate[0]][e.coordinate[1] + SIZE_HORIZON // 2] = "/ "
        if (e.kind == BACKSLASH):
            board[e.coordinate[0]][e.coordinate[1] + SIZE_HORIZON // 2] = "\\ "
        if (e.kind == HORIZON):
            board[e.coordinate[0]][e.coordinate[1] + SIZE_HORIZON // 2] = " -"
        if (e.kind == VERTICAL):
            board[e.coordinate[0]][e.coordinate[1] + SIZE_HORIZON // 2] = " |"

    for rb in board:
        print("".join(rb))


root = TreeNode(51, 5)
make_rand_tree(root)
create_print_info(root, (0, 0))
print_tree()
