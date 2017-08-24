import re, os, codecs
import date_util

class SrtEditor:
    def __init__(self):
        pass

    def time_shift(self, line, during):
        fmt = r"%H:%M:%S,%f"
        rst = re.findall(r'\d+:\d+:\d+,\d+', line)
        if len(rst) == 0:
            return line
        return date_util.add_str_time(rst[0], fmt, during) + " --> " + \
            date_util.add_str_time(rst[1], fmt, during) + "\r\n"

    def del_row(self, line_info, del_line_info):
        """ line_info(line, lineno), del_line_info(lineno_str, lineno_end) """
        if del_line_info[0] <= line_info[1] and line_info[1] <= del_line_info[1]:
            return None
        return line_info[0]

    def inplace(self, orig_path, encoding='utf-8'):
        """Modify a file in-place, with a consistent encoding."""
        new_path = orig_path + '.modified'
        lineno = 0
        with codecs.open(orig_path, encoding=encoding) as orig:
            with codecs.open(new_path, 'wb', encoding=encoding) as new:
                for line in orig:
                    lineno += 1
                    yield line, new, lineno
        os.rename(orig_path, orig_path + ".bk")
        os.rename(new_path, orig_path)
