from pkg.file import find_file

root_path = r"../input"
finder = find_file.FindFile(root_path)

f_names = ["a1.txt", "z.txt"]

f_paths = finder.get_file_by_name(None, ["a", "b"], [r"a\aa"])

#f_paths = finder.get_file_in_dir(["bb"])

for f in f_paths:
    print(f)

print("end")