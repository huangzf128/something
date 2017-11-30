import os, time
from . import base_file
from string import similar, str_tools

class FindFile(base_file.BaseFile):
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

    def similar_name(self, file_name, similar_rate=1):

        file_list = []
        for path, subdirs, files in os.walk(self.search_in_folder):
            for name in files:
                if similar_rate == 1 and file_name == name:
                    file_list.append(os.path.join(path, name))
                else:
                    # rate = self.get_filename_similar_rate(file_name, name)
                    rate = similar.get_similar_rate(file_name, name)
                    if rate >= similar_rate:
                        file_list.append(os.path.join(path, name))
        return file_list

    def get_all_exclude(self, exclude_files, exclude_folders):
        file_list = []
        for path, subdirs, files in os.walk(self.search_in_folder):
            subdirs[:] = [d for d in subdirs if d not in exclude_folders]
            for name in files:
                if not str_tools.exists_in_list_reg(name, exclude_files):
                    file_list.append(os.path.join(path, name))
        return file_list

    def get_all_reg(self, target_reg):
        file_list = []
        for path, subdirs, files in os.walk(self.search_in_folder):
            for name in files:
                if str_tools.exists_in_list_reg(name, target_reg):
                    file_list.append(os.path.join(path, name))
        return file_list

if __name__ == "__main__":
    search_in_folder = r"E:\something\code\python"
    output_path = os.getcwd() + r"\output"

    find_file = FindFile(search_in_folder)

    # file_list = find_file.modifiedtime_greater_then(r"2017/09/04 01:01")
    # find_file.copy_file_to_folder(file_list, output_path)

    file_list = find_file.find_file_by_similar_name("music", 0.5)
    find_file.copy_file_to_folder(file_list, output_path)
