from hzf.file import copy_file, find_file, find_file_reg
import re

root_dir = r"data"
output_dir = r"data\output"

finder = find_file.FindFile(root_dir)
file_list = finder.get_file_in_dir()

# file = copy_file.CopyFile()
# file.copy_files_keep_structure(file_list, output_dir, root_dir)

file_list = finder.get_file_by_name(["001.txt"])
print(file_list)

file_list = finder.get_file_by_modifiedtime("2022/01/19 13:01", 2)
print(file_list)

finder = find_file_reg.FindFileReg(root_dir)
file_list = finder.get_file_by_name_reg([r'.*'])
for f in file_list:
    print(re.sub(r'^(.*)0(01\.txt)$', r'\g<1>1\2', f))
