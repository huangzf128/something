import os, time, difflib
from . import base_file

class FindFile(base_file.File):
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

    def find_file_by_similar_name(self, file_name, similar_rate=1):

        file_list = []
        for path, subdirs, files in os.walk(self.search_in_folder):
            for name in files:
                if similar_rate == 1 and file_name == name:
                    file_list.append(os.path.join(path, name))
                else:
                    rate = self.get_filename_similar_rate(file_name, name)
                    if rate >= similar_rate:
                        file_list.append(os.path.join(path, name))
        return file_list

    def get_filename_similar_rate(self, file_nm1, file_nm2):
        return difflib.SequenceMatcher(None, file_nm1, file_nm2).ratio()


if __name__ == "__main__":
    search_in_folder = r"E:\something\code\python"
    output_path = os.getcwd() + r"\output"

    find_file = FindFile(search_in_folder)

    # file_list = find_file.modifiedtime_greater_then(r"2017/09/04 01:01")
    # find_file.copy_file_to_folder(file_list, output_path)

    file_list = find_file.find_file_by_similar_name("music", 0.5)
    find_file.copy_file_to_folder(file_list, output_path)
