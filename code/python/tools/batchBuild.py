import os, time

rootPath = r"D:\VB\WTMVB\work\S02"
# buildToolPath = "C:\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community\\MSBuild\\15.0\Bin\\msbuild"

# rootPath = r"D:\VB\WTMVB\work\S99"
buildToolPath = r"C:\Windows\Microsoft.NET\Framework\v3.5\MSBuild"

files = [f for f in os.listdir(rootPath) if os.path.isdir(rootPath + "\\" + f) and f != "bin"]

cmd = " \""

for f in files:
    cmd = "call cmd /c \" " + buildToolPath + "\" /clp:NoItemAndPropertyList;ErrorsOnly /m " + rootPath + "\\" + f + "\\" + f + ".sln"
    print(os.system(cmd))

print("OK")
