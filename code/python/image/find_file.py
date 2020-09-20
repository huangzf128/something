from hzf.file.find_file_reg import FindFileReg
from hzf.file.modify_file import ModifyFile

# finder = FindFileReg("F:/E-Book/Temp/JPG")
# file_paths = finder.get_file_by_name_reg([r"^[1-9]\.jpg$"])

# modify = ModifyFile()
# for file_path in file_paths:
#     modify.replace_file_name_regex(file_path, r"(\d)(\.jpg)", r"0\1\2")

finder = FindFileReg("F:/E-Book/Temp/JPG")
file_paths = finder.get_file_by_name_reg([r"^[0-9]+\.pdf$"])
finder.copy_files_to_folder(file_paths, "output")
