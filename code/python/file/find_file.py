from hzf.file import find_file

root_folder = r"D:\work\shinsei"

file_finder = find_file.FindFile(root_folder)
files = file_finder.get_file_by_modifiedtime("2023/07/28", file_finder.COMPARE_GREANTER, ["classes", "work", ".settings"])

files = file_finder.get_file_by_name_reg([".*\\.css"])

print(*files, sep="\n")
