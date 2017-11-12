import shutil, os, ntpath, codecs

class File:
    # base class for handling file

    def __init__(self):
        pass

    # ------------- folder -------------
    def create_folder(self, path_foldername):
        if not os.path.exists(path_foldername):
            os.makedirs(path_foldername)

    def copy_file_to_folder(self, file_list, output_folder):
        # copy file_list to output_folder

        for file in file_list:
            copy_to_path = file.replace(self.search_in_folder, output_folder)
            self.create_folder(os.path.dirname(copy_to_path))
            shutil.copyfile(file, copy_to_path)

    def split_path(self, path):
        # get filename from path

        head, tail = ntpath.split(path)
        return (head, tail or ntpath.basename(head))

    def inplace(self, file_path, encoding='utf-8'):
        """Modify a file in-place, with a consistent encoding."""

        new_path = file_path + '.modified'
        lineno = 0
        with codecs.open(file_path, encoding=encoding) as orig:
            with codecs.open(new_path, 'wb', encoding=encoding) as new_file:
                for line in orig:
                    lineno += 1
                    yield line, lineno, new_file
        os.rename(file_path, file_path + ".bk")
        os.rename(new_path, file_path)

if __name__ == '__main__':
    print(os.path.isfile(r"E:\something\code\python\file\base_file.py"))
