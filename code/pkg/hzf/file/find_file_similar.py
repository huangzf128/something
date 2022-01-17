import os
from hzf.file import base_file
from hzf.string import similar

class FindFileSimilar(base_file.BaseFile):
    # find file in search_in_dir

    def __init__(self, search_in_dir):
        self.search_in_dir = search_in_dir

    def get_file_in_dir_similar(self, similar_rate, d_names):
        return self.get_file_by_name_similar(None, similar_rate, d_names)

    def get_file_by_name_similar(self, f_names, similar_rate, d_names, exclude_d_names=None):
        """     None for all. eg: root/a/b/c/d
                d_names: more level more accuracy. "/" must at head and tail.  eg: /a/b/, /b/, /a/b/c/
                exclude_d_name: folder name
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
                if similar.has_similar_name(name, f_names, similar_rate):
                    file_paths.append(os.path.join(os.path.abspath(path), name))
        return file_paths
