import re

def search_list_reg(patterns, s, ignore=re.IGNORECASE):
    for pattern in patterns:
        if re.search(pattern, s, ignore):
            return True
    return False