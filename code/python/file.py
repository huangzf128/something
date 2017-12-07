from library.pkg.file import find_file

root_folder = r"D:\workspace\SaaS\src\jp\fujitsu\saas\javaWeb\S03"

exclude_files = [r"licenses\.licx", r"vssver2\.scc", r".*\.sln$",
                 r".*\.vbproj$", r".*\.vbproj.user$", r"app.config"]

exclude_folders = []

# find
finder = find_file.FindFile(root_folder)
files = finder.get_file_in_dir([r"S03Common"])

for file in files:
    print(file)

# --------------- copy ---------------
# file_finder = find_file.FindFile(root_folder)
# files = file_finder.get_all_exclude(exclude_files, exclude_folders)
# file_finder.copy_file_to_folder(files, out_folder)


# -------------- delete ---------------


print("end")
