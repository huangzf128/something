import shutil, os, ntpath

class File:
    # base class for handling file

    def __init__(self):
        pass

    def create_folder(self, path_foldername):
        if not os.path.exists(path_foldername):
            os.makedirs(path_foldername)

    def copy_file_to_folder(self, file_list, output_folder):
        # copy file_list to output_folder

        for file in file_list:
            copy_to_path = file.replace(self.search_in_folder, output_folder)
            super().create_folder(os.path.dirname(copy_to_path))
            shutil.copyfile(file, copy_to_path)

    def path_leaf(self, path):
        # get filename from path

        head, tail = ntpath.split(path)
        return tail or ntpath.basename(head)


print(os.path.isfile(r"E:\something\code\python\file\base_file.py"))
