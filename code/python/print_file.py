from pkg.file import find_file

root_folder = r"D:\workspace\SaaS\src\jp\fujitsu\saas\javaWeb\S03"
# root_folder = r"D:\VB\WTMVB"
# root_folder = "input"
# out_folder = r"output"
out_folder = r"D:\VB\WTMVB\work\S02"

exclude_files = [r"licenses\.licx", r"vssver2\.scc", r".*\.sln$",
                 r".*\.vbproj$", r".*\.vbproj.user$", r"app.config"]

exclude_folders = []

file_finder = find_file.FindFile(root_folder)
files = file_finder.get_all_reg([r"executeUpdate"])

for file in files:
    print(file)

print("end")
