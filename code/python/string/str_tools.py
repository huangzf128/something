import re

def match_exists_reg(self, str, reg_list, ignore=re.IGNORECASE):
    for reg in reg_list:
        if re.search(reg, str, ignore):
            return True
    return False
