import os, re, sys, glob
from hzf.file.modify_file import ModifyFile


mf = ModifyFile()
filepath_list = glob.glob(r"D:\html\*.html")
for filepath in filepath_list:
    mf.replace_file_content(filepath, "02_02-1_PrivacyPolicy", "01-07-1_NoPatientInformationErrorMessage", "utf8")
