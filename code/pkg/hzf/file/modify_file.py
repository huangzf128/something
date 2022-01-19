import os, re
from hzf.file import base_file


class ModifyFile(base_file.BaseFile):

    def __init__(self):
        pass

    def replace_file_name(self, target_file_path, old, new):
        (path, file_name) = super(ModifyFile, self).split_path_last(target_file_path)
        os.rename(target_file_path, os.path.join(path, file_name.replace(old, new)))

    def replace_file_name_regex(self, target_file_path, pattern, replace):
        (path, file_name) = super(ModifyFile, self).split_path_last(target_file_path)
        new = re.sub(pattern, replace, file_name)
        os.rename(target_file_path, os.path.join(path, file_name.replace(file_name, new)))

    def replace_file_content(self, target_file_path, old, new, encode=None):
        for line, lineno, new_file in super(ModifyFile, self).inplace(target_file_path, encode):
            new_file.write(line.replace(old, new))
