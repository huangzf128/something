from file import find_file

root_folder = r"C:\Users\fulong\Desktop\ja"
out_folder = r"C:\Users\fulong\Desktop\to"

exclude_files = [r"licenses\.licx", r"vssver2\.scc", r".*\.sln$",
                 r".*\.vbproj$", r".*\.vbproj.user$", r"app.config"]
exclude_folders = [r".svn", r"bin", r"obj"]

file_finder = find_file.FindFile(root_folder)
files = file_finder.get_all_exclude(exclude_files, exclude_folders)
file_finder.copy_file_to_folder(files, out_folder)

print("end")
