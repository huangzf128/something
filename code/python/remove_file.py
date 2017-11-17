from file import find_file
import os

root_folder = r"D:\VB\WTMVB\work"

target_files = [r".*\.cache$"]

file_finder = find_file.FindFile(root_folder)
files = file_finder.get_all_reg(target_files)

for file in files:
    os.remove(file)

print("end")
