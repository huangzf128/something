"""
tackle file
"""
import sys
sys.path.append("../../pkg")

from hzf.file import find_file

ROOT_PATH = r"C:\Users\fulong\Desktop\ja"
OUTPUT = r"C:\Users\fulong\Desktop\to"

exclude_files = []
exclude_folders = []

file_finder = find_file.FindFile(ROOT_PATH)
files = file_finder.get_file_in_dir(None)
file_finder.copy_files_to_folder(files, OUTPUT)

print("end")
