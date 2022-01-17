import shutil, os, ntpath, codecs, stat, datetime

class BaseFile:
    # base class for handling file
    def __init__(self):
        pass

    # --------------- --------------- --------------- folder ---------------
    def create_folder(self, folder_path):
        if not os.path.exists(folder_path):
            os.makedirs(folder_path)

    def remove_folder(self, folder_path):
        if os.path.exists(folder_path):
            shutil.rmtree(folder_path)

    # --------------- --------------- --------------- path ---------------
    def split_path_last(self, path):
        # split path at last separator, the 'last' maybe a file or directory
        init, last = ntpath.split(path)
        return init, last or ntpath.basename(init)

    def split_path_drive(self, path):
        # split path at first separator
        drive, tail = os.path.splitdrive(path)
        return (drive, tail)

    # --------------- --------------- --------------- file ---------------
    def inplace(self, file_path, encoding='utf-8'):
        """ Modify a file in-place, with a consistent encoding."""
        """ this need work with for """

        new_path = file_path + '.modified'
        lineno = 0
        with codecs.open(file_path, encoding=encoding) as orig:
            with codecs.open(new_path, 'wb', encoding=encoding) as new_file:
                for line in orig:
                    lineno += 1
                    yield line, lineno, new_file

        file_name, file_extension = os.path.splitext(file_path)
        # os.rename(file_path, file_name + "_" + datetime.datetime.now().strftime("%H%M%S") + file_extension)
        self.remove_file([file_path])
        os.rename(new_path, file_path)

    def copy_files_to_folder(self, file_list, output_folder):
        """ copy file_list to output_folder """

        self.create_folder(output_folder)

        for file in file_list:
            if not os.path.isfile(file):
                raise Exception('file not exists. file: ' + file)
            
            dir_path, _ = self.split_path_last(file)
            if (dir_path == output_folder):
                raise Exception('file must move to another folder')

            copy_to_path = file.replace(dir_path, output_folder)
            self.create_folder(os.path.dirname(copy_to_path))
            try:
                shutil.copy2(file, copy_to_path)
            except Exception:
                os.chmod(copy_to_path, stat.S_IWRITE)
                # os.remove(copy_to_path)
                shutil.copy2(file, copy_to_path)

    def remove_file(self, file_list):
        for file in file_list:
            if not os.path.isfile(file):
                raise Exception('file not exists. file: ' + file)
            os.remove(file)