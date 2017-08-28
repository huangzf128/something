import os, time

rootPath = r"D:\VB\WTMVB\work\S02"

files = [f for f in os.listdir(rootPath) if not os.path.isdir(f) and f != "bin"]

cmd = "cmd /k \""

for f in files:
    cmd += "msbuild /clp:NoItemAndPropertyList;ErrorsOnly \"" + rootPath + "\\" + f + "\\" + f + ".sln\" & "

cmd += "\""

os.system(cmd)
