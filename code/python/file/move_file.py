from ...py-module.hzf.file import find_file

root_folder = r"E:\workspaceold\abyy\azkw\history\2015\08\20150829010101-20150829010101"
# root_folder = r"D:\VB\WTMVB"
# root_folder = "input"
# out_folder = r"output"
out_folder = r"E:\workspaceold\abyy\azkw\history\2015\08\08_29"

exclude_files = []
exclude_folders = []

file_finder = find_file.FindFile(root_folder)
files = file_finder.get_file_in_dir(None)
file_finder.copy_file_to_folder(files, out_folder)

print("end")
