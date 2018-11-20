from hzf.file import find_file, find_file_reg, find_file_similar

root_path = r"D:\Projects\vb\watami\S02"
finder = find_file.FindFile(root_path)

f_names = ["S02T01F04P01.vb", "S02T01F06.sln"]
d_names = ["\\S02T01F06\\"]
# f_paths = finder.get_file_by_name(f_names, None, None)
# f_paths = finder.get_file_by_name(f_names, d_names , None)

f_paths = finder.get_file_in_dir(d_names)

# f_paths = finder.get_file_not_in_dir(["\\"])
# f_paths = finder.get_file_by_modifiedtime("2017/12/07 09:01", 1)

# finder_reg = find_file_reg.FindFileReg(root_path)

# f_paths = finder_reg.get_file_by_name_reg(["^b.txt$"], None, None)

# finder_similar = find_file_similar.FindFileSimilar(root_path)

# f_paths = finder_similar.get_file_by_name_reg(["b.txt"], 0.9, None, None)

for f in f_paths:
    print(f)


print("end")
