import os, time
from . import base_file
from ..string import similar, str_tools

class FindFile(base_file.BaseFile):
    # find file in search_in_dir

    def __init__(self, search_in_dir):
        self.search_in_dir = search_in_dir

    def get_file_in_dir(self, d_names):
        return self.get_file_by_name(None, d_names, None)

    def get_file_by_name(self, f_names, d_names, exclude_d_names):
        '''    f_names: None for all file   '''
        '''    d_names: more level more accuracy   eg: a/b, b, a/b/c '''
        '''    exclude_d_name: must absolute path from root, no "/" at head and tail eg:root/a/b   '''

        file_paths = []
        r_path_len = len(self.search_in_dir)
        for path, subdirs, files in os.walk(self.search_in_dir):
            sub_path = path[r_path_len + 1: ]
            if exclude_d_names is not None:
                subdirs[:] = [d for d in subdirs if os.path.join(sub_path, d) not in exclude_d_names]

            for d in d_names:
                if d in (path + "\\"):
                    break
            else:
                continue

            for name in files:
                if f_names is None or name in f_names:
                    file_paths.append(os.path.join(os.path.abspath(path), name))
        return file_paths


    def get_file_by_modifiedtime_greater_then(self, modifiedtime):
        # find the file that last updatetime is greater then modifiedtime

        file_list = []
        for path, subdirs, files in os.walk(self.search_in_dir):
            for name in files:
                file_path = os.path.join(path, name)
                updatetime = time.strftime('%Y/%m/%d %H:%M', time.localtime(os.path.getmtime(file_path)))
                if updatetime > modifiedtime:
                    file_list.append(file_path)
        return file_list


    def get_all_exclude(self, exclude_files, exclude_folders):
        file_list = []
        for path, subdirs, files in os.walk(self.search_in_dir):
            subdirs[:] = [d for d in subdirs if d not in exclude_folders]
            for name in files:
                if not str_tools.match_exists_reg(name, exclude_files):
                    file_list.append(os.path.join(path, name))
        return file_list

