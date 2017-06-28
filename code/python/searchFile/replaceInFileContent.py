import os, time, fileinput, sys

rootPath = os.path.join(os.getcwd(), "")
s_target = "S03T02F01"
s_replace = "S03T05F22"


def replace_file_name(target):
    return target.replace(s_target, s_replace)


def replace_file_content(target_file_path):
    with fileinput.FileInput(target_file_path, inplace=True) as file:
        for line in file:
            print(line.replace(s_target, s_replace), end='')

for path, subdirs, files in os.walk(rootPath):
    for name in files:
        if name != "replace.py":
            replace_file_content(os.path.join(path, name))
            os.rename(os.path.join(path, name), os.path.join(path, replace_file_name(name)))
        
