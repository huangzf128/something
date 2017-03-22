# -*- coding: utf-8 -*-
import os, difflib

# variable declare
musicRootPath = 'F:\\Music\\之丹丹歌曲'

duplicateFileDict = {}

# function definition
def isTargetFile(file):
    if file in ["desktop.ini", "Thumbs.db"]:
        return False
    return True

def getFileSimilarRate(file1, file2):
    rate = difflib.SequenceMatcher(None, file1, file2).ratio()
    return rate

def getSimilarFile(file, dict):
    for key in dict.keys():
        rate = getFileSimilarRate(key, file)
        if rate >= 0.8:
            return key
    return None

# main1
for root, dirs, files in os.walk(musicRootPath):
    for file in files:
        if not isTargetFile(file):
            continue
        key = getSimilarFile(file, duplicateFileDict)
        if key is not None:
            duplicateList = duplicateFileDict[key]
            duplicateList.append(os.path.join(root, file))
        else:
            duplicateFileDict[file] = [os.path.join(root, file)]

for file, fileFullPath in duplicateFileDict.items():
    if len(fileFullPath) > 1:
        print(file)
        set(map(lambda x: print(x), fileFullPath))
        print()

print(len(duplicateFileDict))
