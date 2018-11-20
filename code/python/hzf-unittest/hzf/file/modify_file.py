import os, re
from . import base_file

class ModifyFile(base_file.BaseFile):

    def __init__(self):
        pass

    def replace_file_content(self, target_file_path, old, new):
        for line, lineno, new_file in super(ModifyFile, self).inplace(target_file_path):
            new_file.write(line.replace(old, new))

    def replace_file_name(self, target_file_path, old, new):
        (path, file_name) = super(ModifyFile, self).split_path(target_file_path)
        os.rename(target_file_path, os.path.join(path, file_name.replace(old, new)))

    def replace_file_name_regex(self, target_file_path, pattern, replace):
        (path, file_name) = super(ModifyFile, self).split_path(target_file_path)
        new = re.sub(pattern, replace, file_name)
        os.rename(target_file_path, os.path.join(path, file_name.replace(file_name, new)))

if __name__ == "__main__":
    rootPath = os.path.join(os.getcwd(), r"C:\Users\FULONG\Desktop\比較\WATAMIKINTAI_PKGB")
    s_target = "a"
    s_replace = "b"

    modify_file = ModifyFile()

    for path, subdirs, files in os.walk(rootPath):
        for name in files:
            # modify_file.replace_file_content(os.path.join(path, name), s_target, s_replace)
            # modify_file.replace_file_name(os.path.join(path, name), s_target, s_replace)
            modify_file.replace_file_name_regex(os.path.join(path, name), r"(.+)B(.+)$", r"\1\2")
    print("OK")
