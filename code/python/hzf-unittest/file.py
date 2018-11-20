from hzf.file import base_file

# ------------------------------ base_file -----
bfile = base_file.BaseFile()

# ===== folder
testfolder = r"D:\something.git\code\python\hzf-testcase\temp\testfolder"
bfile.create_folder(testfolder)
bfile.remove_folder(testfolder)

# ===== path
print(bfile.split_path_drive(testfolder))
print(bfile.split_path_last(testfolder))

# ===== file
file_list = [r"D:\something.git\code\python\hzf-testcase\temp\a.txt"]
bfile.copy_files_to_folder(file_list, r"D:\something.git\code\python\hzf-testcase\temp\output")

remove_file_list = [r"D:\something.git\code\python\hzf-testcase\temp\output\a.txt"]
bfile.remove_file(remove_file_list)


for line, lineno, new_file in bfile.inplace(file_list[0]):
    new_file.write(line.replace("d", 'e'))


print("end")
