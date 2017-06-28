from openpyxl import load_workbook
import os, re, codecs

table_dictionary_path = os.path.join(os.getcwd(), "dictionary.mac")
sql_path = os.path.join(os.getcwd(), "sql.txt")
sql_new_path = os.path.join(os.getcwd(), "sql_new.txt")

def read_file(path):
    with codecs.open(path, 'r', 'utf-8') as f:
        return f.read().splitlines()

def write_file(lines):
    with codecs.open(sql_new_path, 'w', 'utf-8') as f:
        for line in lines:
            f.write(line + "\n")

def sql_replace(old, new, values, prefixs):
    
    new_value = []
    for value in values:
        for prefix in prefixs:
            value = value.replace(prefix + old, prefix + new)
        new_value.append(value)
    return new_value

def sql_filter(value):
    value.replace(":", "")

# ============================================
sqls = read_file(sql_path)

infos = read_file(table_dictionary_path)
replace_flg = 1

for info in infos:

    if replace_flg == 1 and info == "//===common===":
        replace_flg = 0

    key_value = info.split(",,")    

    if replace_flg == 1:
        prefixs = ["	", ".", " "]
    else:
        prefixs = [""]

    if len(key_value) >= 2:
        sqls = sql_replace(key_value[0], key_value[1], sqls, prefixs)        


write_file(sqls)
print("end......")
