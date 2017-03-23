import os, time
from shutil import copyfile1

rootPath = "E:\\prac"
outRootPath = os.getcwd() + "\\outputFolder"

def createFolder(path):
    if not os.path.exists(path):
        os.makedirs(path)

for path, subdirs, files in os.walk(rootPath):
    for name in files:
        filePath = os.path.join(path, name)
        updateTime = time.strftime('%Y/%m/%d %H:%M', time.localtime(os.path.getmtime(filePath)))
        if updateTime > "2017/02/01 16:01":
            print(filePath)
            # dir_path = os.path.dirname(os.path.realpath(__file__))
            createFolder(outRootPath)
            copyPath = outRootPath + filePath.replace(rootPath, "")
            createFolder(os.path.dirname(copyPath))
            copyfile(filePath, copyPath)
