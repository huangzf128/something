import re
from hzf.file import find_file

root_folder = r"D:\work\shinsei"

finder = find_file.FindFile(root_folder)
file_list = finder.get_all_file()

for f in file_list:
    new_f = re.sub(r'^(.+?)(\.png)$', r'\g<2>----\g<1>', f)
    # os.rename(f, new_f)
    print(new_f)
