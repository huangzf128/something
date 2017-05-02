# reference:
# https://support.microsoft.com/en-us/help/318785/how-to-determine-which-versions-and-service-pack-levels-of-the-microsoft-.net-framework-are-installed
# https://msdn.microsoft.com/en-us/library/hh925568(v=vs.110).aspx#net_a

import winreg, os

# < 4.0
root_key_path = r'SOFTWARE\Microsoft\NET Framework Setup\NDP'
rKey = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, root_key_path, 0, winreg.KEY_READ)

def get_value(regKey, name):
    try:
        v, _ = winreg.QueryValueEx(regKey, name)
        return v
    except EnvironmentError:
        return ""

def get_key_info(key):
    ins = get_value(key, "Install")
    sp = get_value(key, "SP")
    ver = get_value(key, "Version")
    return (ins, sp, ver)

# QueryInfoKey: return tuple (subkey num, value num, about last modified)

for i in range(winreg.QueryInfoKey(rKey)[0]):
    key_name = winreg.EnumKey(rKey, i)
    key_path = os.path.join(root_key_path, key_name)
    key = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, key_path, 0, winreg.KEY_READ)
    ins, s, v = get_key_info(key)
    if ins == "" and s == "" and v == "":
        continue
    if ins == "":
        print(key_name + " " + v)
    else:
        if(s != "" and ins == 1):
            print(key_name + " " + v + " sp" + str(s))

    if v != "":
        continue
    else:
        for j in range(winreg.QueryInfoKey(key)[0]):
            try:
                sub_key_name = winreg.EnumKey(key, j)
                sub_key_path = os.path.join(key_path, sub_key_name)
                sKey = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, sub_key_path, 0, winreg.KEY_READ)
                ins, s_s, v = get_key_info(sKey)
            finally:
                winreg.CloseKey(sKey)

            if v != "":
                s = s_s
            if ins == "" and s == "" and v == "":
                break
            if ins == "":
                print(key_name + " " + v)
            else:
                if(s != "" and ins == 1):
                    print(" " + sub_key_name + " " + v + " sp" + str(s))
                elif (ins == 1):
                    print(" " + sub_key_name + " " + v)
winreg.CloseKey(rKey)

# >= 4.5
root_key_path = r"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"
rKey = winreg.OpenKey(winreg.HKEY_LOCAL_MACHINE, root_key_path, 0, winreg.KEY_READ)
release = get_value(rKey, "Release")
if ((release >= 378389)):
    print("4.5")
if ((release >= 378675)):
    print("4.5.1")
if ((release >= 379893)):
    print("4.5.2")
if (release >= 393295):
    print("4.6")
if (release >= 394254):
    print("4.6.1")
if (release >= 394802):
    print("4.6.2")
if (release >= 460798):
    print("4.7 or later")
