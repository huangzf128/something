from pickle import FALSE, TRUE
import shutil, os, ntpath, codecs, datetime, stat


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

    def is_parent_path(self, parent_path, child_path):
        # Smooth out relative path names, note: if you are concerned about symbolic links, you should use os.path.realpath too
        parent_path = os.path.abspath(parent_path)
        child_path = os.path.abspath(child_path)

        # Compare the common path of the parent and child path with the common path of just the parent path. 
        # Using the commonpath method on just the parent path will regularise the path name in the same way as the comparison that deals with both paths, removing any trailing path separator
        return os.path.commonpath([parent_path]) == os.path.commonpath([parent_path, child_path])

    # --------------- --------------- --------------- file ---------------
    def copy_files_to_folder(self, file_list, output_dir):
        """ copy file to output_dir,  should be check before call this function """
        for f in file_list:
            try:
                shutil.copy2(f, output_dir)
            except Exception:
                os.chmod(output_dir, stat.S_IWRITE)
                shutil.copy2(f, output_dir)

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

    def remove_file(self, file_list):
        for file in file_list:
            if not os.path.isfile(file):
                raise Exception('file not exists. file: ' + file)
            os.remove(file)