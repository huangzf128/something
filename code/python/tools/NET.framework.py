from winreg import *
import os

rootKey = r'SOFTWARE\Microsoft\NET Framework Setup\NDP'
aKey = OpenKey(HKEY_LOCAL_MACHINE, rootKey, 0, KEY_READ)

def get_value_info(key):
    try:
        ins, _ = QueryValueEx(key, "Install")
        sp, _ = QueryValueEx(key, "SP")
        ver, _ = QueryValueEx(key, "Version")
        print(ins, sp, ver)
    except EnvironmentError:
        return

for i in range(QueryInfoKey(aKey)[0]):
    # n, v, t = EnumValue(aKey, i)
    # print(i, n, v, t)
    sub_key_path = os.path.join(rootKey, EnumKey(aKey, i))
    s_key = OpenKey(HKEY_LOCAL_MACHINE, sub_key_path, 0, KEY_READ)
    get_value_info(s_key)

CloseKey(aKey)
