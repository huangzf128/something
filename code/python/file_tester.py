from hzf.file import find_file, find_file_reg, find_file_similar, base_file

#root_path = r"../input"
#finder = find_file.FindFile(root_path)

#f_names = ["a1.txt", "z.txt"]

#f_paths = finder.get_file_by_name(["z.txt"], ["\\aa\\"], None)
#f_paths = finder.get_file_in_dir(["\\"])
#f_paths = finder.get_file_not_in_dir(["\\"])
#f_paths = finder.get_file_by_modifiedtime("2017/12/07 09:01", 1)

#finder_reg = find_file_reg.FindFileReg(root_path)

#f_paths = finder_reg.get_file_by_name_reg(["^b.txt$"], None, None)

# finder_similar = find_file_similar.FindFileSimilar(root_path)

# f_paths = finder_similar.get_file_by_name_reg(["b.txt"], 0.9, None, None)

# for f in f_paths:
#     print(f)

bfile = base_file.BaseFile()

file_list = [r"D:\something.git\code\a.txt"]
bfile.copy_files_to_folder(file_list, r"D:\something.git\code\lib")

#(drive, tail) = bfile.split_path_drive(path="c:\\aaa\bbb\ccc")
#print(drive)


print("end")