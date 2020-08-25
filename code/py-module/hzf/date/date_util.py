from datetime import datetime, timedelta
from dateutil.relativedelta import relativedelta
from calendar import monthrange

FMT_YMDHMS = "%Y%m%d %H%M%S"
FMT_YMD = "%Y%m%d"
FMT_HMS = "%H%M%S"

# ----------------------- converter ----
def datetime_2_str(date, fmt=FMT_YMDHMS):
    return date.strftime(fmt)

def str_2_datetime(str, fmt):
    return datetime.strptime(str, fmt)

# ----------------------- calculate ----
def add_datetime(dt, day=0, hour=0, min=0, sec=0):
    return dt + timedelta(days=day, hours=hour, minutes=min, seconds=sec)

def add_month(dt, month):
    return dt + relativedelta(months=1)

def num_of_days_in_month(dt):
    weekNo, lastday = monthrange(dt.year, dt.month)
    return lastday

def first_day_of_week(dt):
    return dt - timedelta(days=dt.weekday())

def last_day_of_week(dt):
    return first_day_of_week(dt) + timedelta(days=6)

def first_day_of_month(dt):
    return datetime(dt.year, dt.month, 1)

def last_day_of_month(dt):
    return add_datetime(add_month(first_day_of_month(dt), 1), day=-1)
