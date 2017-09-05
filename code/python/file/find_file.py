import os, time
import base_file

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


if __name__ == "__main__":
    search_in_folder = r"E:\TDDOWNLOAD\[kamigami.org] Fairy Tail 01-175 Fin [1280x720 R10 AAC RMVB Sub(Chi,Jap)]"
    output_path = os.getcwd() + r"\outputFolder"

    find_file = FindFile(search_in_folder)
    file_list = find_file.modifiedtime_greater_then(r"2017/09/04 01:01")
    find_file.copy_file_to_folder(file_list, output_path)

    print("OK")
