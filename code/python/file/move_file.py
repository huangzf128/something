"""
tackle file
"""
import sys
sys.path.append("../../pkg")

from hzf.file import copy_file, find_file

root_dir = r"C:\Users\fulong\Desktop\ja"
output_dir = r"C:\Users\fulong\Desktop\to"

finder = find_file.FindFile(root_dir)
file_list = finder.get_file_in_dir()

file = copy_file.CopyFile()
# file.copy_files_keep_structure(file_list, output_dir, root_dir)
file.copy_files_nokeep_structure(file_list, output_dir)
