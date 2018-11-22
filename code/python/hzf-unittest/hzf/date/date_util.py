from datetime import datetime, timedelta

FMT_YMDHMS = "%Y%m%d %H%M%S"
FMT_YMD = "%Y%m%d"
FMT_HMS = "%H%M%S"

# ----------------------- converter ----
def datetime_2_str(date, fmt=FMT_YMDHMS):
    return date.strftime(fmt)

def str_2_datetime(str, fmt):
    return datetime.strptime(str, fmt)

# ----------------------- calculate ----

def add_day(dt, day, min):
    during = timedelta(days=day, minutes=min)
    return (dt + during)
