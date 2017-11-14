from file import find_file

file_finder = find_file.FindFile("a")
files = file_finder.find_file_by_similar_name("e", 0)
file_finder.copy_file_to_folder(files, "output")
print(files)
