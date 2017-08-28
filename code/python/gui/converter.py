import datetime

def datetime_2_str(date, fmt):
    return date.strftime(fmt)[:-3]

def str_2_datetime(str, fmt):
    return datetime.datetime.strptime(str, fmt)
