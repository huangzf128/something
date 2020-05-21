from hzf.file import find_file, find_file_reg, find_file_similar, modify_file
import os

root_path = os.path.abspath(r"C:\Users\fulong\Desktop\sql\PACKAGE_BODY")
finder = find_file.FindFile(root_path)

f_paths = []
f_names = ["file.py", "find_file.py"]
d_names = ["\\hzf-unittest\\hzf\\"]

# ================================================================ find

# --- get file by name
# f_paths = finder.get_file_by_name(f_names, None, None)
# f_paths = finder.get_file_by_name(f_names, d_names, None)

# --- get file by dir
# f_paths = finder.get_file_in_dir(d_names)
# f_paths = finder.get_file_by_modifiedtime("2018/11/20 09:01", finder.COMPARE_GREANTER, ["__pycache__"])

# ================================================================ reg

finder_reg = find_file_reg.FindFileReg(root_path)
f_paths = finder_reg.get_file_by_name_reg(["^.*sql$"], None, None)

# ================================================================ similar

# finder_similar = find_file_similar.FindFileSimilar(root_path)
# f_paths = finder_similar.get_file_by_name_similar(["musci-prase"], 0.7, None, None)

# ================================================================ modify


mfile = modify_file.ModifyFile()

for f in f_paths:
    mfile.replace_file_name_regex(f, r"(.+)(\.sql)$", r"\1B\2")


# -------------------- output
for f in f_paths:
    print(f)

print("end")
