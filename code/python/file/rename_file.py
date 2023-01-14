"""
tackle file
"""
import sys, re, os
sys.path.append("../../pkg")

from hzf.file import copy_file, find_file

root_dir = r"D:\E-Book\人物传记\bin\aimi\aimi  Shin Shuku Satsu 2 (219)"
output_dir = r"C:\Users\fulong\Desktop\to"

finder = find_file.FindFile(root_dir)
file_list = finder.get_file_in_dir()

for f in file_list:
    new_f = re.sub(r'^(.*?)0(.+\.jpeg)$', r'\g<1>1\2', f)
    # os.rename(f, new_f)
