from hzf.file import find_file, copy_file

root_folder = r"D:\work\shinsei"
out_folder = r"D:\work\copy"

exclude_files = [r"licenses\.licx", r"vssver2\.scc", r".*\.sln$",
                 r".*\.vbproj$", r".*\.vbproj.user$", r"app.config"]
exclude_folders = [r".svn", r"bin", r"obj"]

file_finder = find_file.FindFile(root_folder)
files = file_finder.get_file_by_name(None, None, ["css"])

coper = copy_file.CopyFile()
coper.copy_files_keep_structure(files, root_folder, out_folder)
# for move: coper.remove_file


print("end")
