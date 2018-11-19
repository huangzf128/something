from file import base_file

if __name__ == "__main__":
    f = base_file.BaseFile()
    print(f.split_path_last_separator("c://aaa//ddd//bbb.txt"))
