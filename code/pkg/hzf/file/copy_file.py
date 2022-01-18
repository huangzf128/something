from distutils.file_util import copy_file
import os, time, shutil, stat
from hzf.file import base_file


class CopyFile(base_file.BaseFile):
    """ Copy file """

    def __init__(self):
        super().__init__()

    def copy_files_nokeep_structure(self, file_list, output_folder, ignore_notexist=True):
        """ copy file_list to output_folder """

        copy_file_list = []
        for file in file_list:
            if not os.path.isfile(file):
                if ignore_notexist:
                    continue
                else:
                    raise Exception('file not exists. file: ' + file)

            dir_path, _ = self.split_path_last(file)
            if (dir_path == output_folder):
                continue

            copy_file_list.append(file)

        self.create_folder(output_folder)
        for f in copy_file_list:
            try:
                shutil.copy2(f, output_folder)
            except Exception:
                os.chmod(output_folder, stat.S_IWRITE)
                shutil.copy2(f, output_folder)

    def copy_files_keep_structure(self, file_list, output_folder, root_folder, ignore_notexist=True):
        """ copy file_list to output_folder """

        copy_file_list = []
        for file in file_list:
            if not os.path.isfile(file):
                if ignore_notexist:
                    continue
                else:
                    raise Exception('file not exists. file: ' + file)

            dir_path, _ = self.split_path_last(file)
            if (dir_path == output_folder):
                continue

            copy_to_path = file.replace(root_folder, output_folder)
            copy_file_list.append((file, copy_to_path))

        for f, to_file in copy_file_list:
            shutil.copyfile(f, to_file)
