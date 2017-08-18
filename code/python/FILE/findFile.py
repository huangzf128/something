import os, time
from shutil import copyfile

class File:
    # base class for handling file

    def __init__(self):
        pass

    def createFolder(self, path_foldername):
        if not os.path.exists(path_foldername):
            os.makedirs(path_foldername)

class FindFile(File):
    # find file in search_in_folder

    def __init__(self, search_in_folder):
        self.search_in_folder = search_in_folder

    def modifiedtime_greater_then(self, modifiedtime):
        # find the file that last updatetime is greater then modifiedtime

        file_list = []
        for path, subdirs, files in os.walk(self.search_in_folder):
            for name in files:
                file_path = os.path.join(path, name)
                updatetime = time.strftime('%Y/%m/%d %H:%M', time.localtime(os.path.getmtime(file_path)))
                if updatetime > modifiedtime:
                    file_list.append(file_path)
        return file_list

    def copy_file_to_folder(self, file_list, output_folder):
        # copy file_list to output_folder

        for file in file_list:
            copy_to_path = file.replace(self.search_in_folder, output_folder)
            super().createFolder(os.path.dirname(copy_to_path))
            copyfile(file, copy_to_path)

search_in_folder = r"D:\workspace\SaaS\src"
output_path = os.getcwd() + "\\outputFolder"

find_file = FindFile(search_in_folder)
file_list = find_file.modifiedtime_greater_then(r"2017/08/13 01:01")
find_file.copy_file_to_folder(file_list, output_path)

print("OK")
