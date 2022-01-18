import os
from hzf.file import base_file
from hzf.string import regex


class FindFileReg(base_file.BaseFile):
    # find file in search_in_dir

    def __init__(self, search_in_dir):
        self.search_in_dir = search_in_dir

    def get_file_in_dir_reg(self, d_names):
        return self.get_file_by_name_reg(None, d_names)

    def get_file_by_name_reg(self, f_name_patterns, d_names=None, exclude_d_names=None):
        """     None for all. eg: root/a/b/c/d
                d_names: more level more accuracy. "/" must at head and tail.  eg: /a/b/, /b/, /a/b/c/
                exclude_d_name: must folder
        """

        file_paths = []
        r_path_len = len(self.search_in_dir)
        for path, subdirs, files in os.walk(self.search_in_dir):
            sub_path = "\\" + path[r_path_len + 1:]

            if exclude_d_names is not None:
                subdirs[:] = [d for d in subdirs if d not in exclude_d_names]

            if d_names is not None:
                for d in d_names:
                    if d in (sub_path + "\\"):
                        break
                else:
                    continue

            for name in files:
                if regex.search_list_reg(f_name_patterns, name):
                    file_paths.append(os.path.join(os.path.abspath(path), name))
        return file_paths
