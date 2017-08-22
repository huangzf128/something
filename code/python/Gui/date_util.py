import converter

def add_str_time(str_time, fmt, during):
    time = converter.str_2_datetime(str_time, fmt)
    return converter.datetime_2_str(time + during, fmt)
