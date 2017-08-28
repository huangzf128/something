import os, fileinput
import base_file

class ModifyFile(base_file.File):

    def __init__(self):
        pass

    def replace_file_content(self, target_file_path, old, new):
        with fileinput.FileInput(target_file_path, inplace=True) as file:
            for line in file:
                print(line.replace(old, new), end='')

    def replace_file_name(self, target_file_path, old, new):
        file_name = super.path_leaf(target_file_path)
        return file_name.replace(old, new)

if __name__ == "__main__":
    rootPath = os.path.join(os.getcwd(), "")
    s_target = "S03T02F01"
    s_replace = "S03T05F22"

    modify_file = ModifyFile()

    for path, subdirs, files in os.walk(rootPath):
        for name in files:
            if name != "replace.py":
                modify_file.replace_file_content(os.path.join(path, name))
                os.rename(os.path.join(path, name), os.path.join(path, replace_file_name(name)))
