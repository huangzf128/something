import os, time
from . import base_file
from ..string import str_tools

class FindFile(base_file.BaseFile):
    # find file in search_in_dir

    def __init__(self, search_in_dir):
        self.search_in_dir = search_in_dir

    def get_file_in_dir(self, d_names):
        return self.get_file_by_name(None, d_names)

    def get_file_not_in_dir(self, exclude_d_names):
        return self.get_file_by_name(None, None, exclude_d_names)

    def get_file_by_file_name(self, f_names, d_names):
        return self.get_file_by_name(f_names, d_names)

    def get_file_by_name(self, f_names, d_names, exclude_d_names=None):
        """     None for all. eg: root/a/b/c/d
                d_names: more level more accuracy. "/" must at head and tail.  eg: /a/b/, /b/, /a/b/c/
                exclude_d_name: must absolute path from root, "/" must at head and tail eg: root/a/b
        """

        file_paths = []
        r_path_len = len(self.search_in_dir)
        for path, subdirs, files in os.walk(self.search_in_dir):
            sub_path = "\\" + path[r_path_len + 1: ]
            if exclude_d_names is not None:
                subdirs[:] = [d for d in subdirs if os.path.join(sub_path, d + "\\") not in exclude_d_names]

            if d_names is not None:
                for d in d_names:
                    if d in (sub_path + "\\"):
                        break
                else:
                    continue

            for name in files:
                if f_names is None or name in f_names:
                    file_paths.append(os.path.join(os.path.abspath(path), name))
        return file_paths


    def get_file_by_modifiedtime(self, modifiedtime, compare_type):
        """ find the file that last updatetime is greater then modifiedtime,  eg: yyyy/mm/dd hh:mi
            compare_type: 0 for equal; 1 for greater than; 2 for less then;
        """

        file_list = []
        for path, subdirs, files in os.walk(self.search_in_dir):
            for name in files:
                file_path = os.path.join(path, name)
                updatetime = time.strftime('%Y/%m/%d %H:%M', time.localtime(os.path.getmtime(file_path)))
                if ((compare_type == 0 and updatetime == modifiedtime)  or
                    (compare_type == 1 and updatetime > modifiedtime)   or
                    (compare_type == 2 and updatetime < modifiedtime)):
                    file_list.append(os.path.abspath(file_path))
        return file_list

