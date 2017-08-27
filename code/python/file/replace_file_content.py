import os, fileinput
import base_file

class ModifyFile(base_file.File):

    def __init__(self, file_path):
        self.file_path = file_path

    def replace_file_content(self, target_file_path, old, new):
        with fileinput.FileInput(target_file_path, inplace=True) as file:
            for line in file:
                print(line.replace(old, new), end='')


if __name__ == "__main__":
    rootPath = os.path.join(os.getcwd(), "")
    s_target = "S03T02F01"
    s_replace = "S03T05F22"


for path, subdirs, files in os.walk(rootPath):
    for name in files:
        if name != "replace.py":
            replace_file_content(os.path.join(path, name))
            os.rename(os.path.join(path, name), os.path.join(path, replace_file_name(name)))
