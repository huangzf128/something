import os
import base_file

class ModifyFile(base_file.File):

    def __init__(self):
        pass

    def replace_file_content(self, target_file_path, old, new):
        for line, lineno, new_file in super(ModifyFile, self).inplace(target_file_path):
            new_file.write(line.replace(old, new))

    def replace_file_name(self, target_file_path, old, new):
        (path, file_name) = super(ModifyFile, self).split_path(target_file_path)
        os.rename(target_file_path, os.path.join(path, file_name.replace(old, new)))

if __name__ == "__main__":
    rootPath = os.path.join(os.getcwd(), "outputFolder")
    s_target = "a"
    s_replace = "b"

    modify_file = ModifyFile()

    for path, subdirs, files in os.walk(rootPath):
        for name in files:
            modify_file.replace_file_content(os.path.join(path, name), s_target, s_replace)
            modify_file.replace_file_name(os.path.join(path, name), s_target, s_replace)

    print("OK")
