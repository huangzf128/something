import os, time
from shutil import copyfile

rootPath = "D:\\ProjectDocument\\TrustEye\\pleiades\\workspace\\\
TrustEye\\src\\main\\java\\com\\fpsol\\trusteye"


def createFolder(path):
    if not os.path.exists(path):
        os.makedirs(path)

for path, subdirs, files in os.walk(rootPath):
    for name in files:
        filePath = os.path.join(path, name)
        currentPath = os.getcwd()
        updateTime = time.strftime('%Y/%m/%d %H:%M', time.localtime(os.path.getmtime(filePath)))
        if updateTime > "2017/03/10 16:01":
            print(filePath)
            # dir_path = os.path.dirname(os.path.realpath(__file__))
            createFolder(currentPath + "\\files")
            copyfile(filePath, currentPath + "\\files\\" + name)
