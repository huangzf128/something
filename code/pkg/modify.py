import os, re, sys, glob
from hzf.file.modify_file import ModifyFile


mf = ModifyFile()
filepath_list = glob.glob(r"D:\Projects\vb\WTM\work\S99\S99T03F53\S99T03F53\*")
for filepath in filepath_list:
    mf.replace_file_name(filepath, "S99T03F54", "S99T03F53")
