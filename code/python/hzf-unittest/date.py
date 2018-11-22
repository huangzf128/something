from datetime import datetime
from hzf.date import date_util

d = date_util.datetime_2_str(datetime.now(), date_util.FMT_YMD)
d = date_util.str_2_datetime(d, date_util.FMT_YMD)

d = date_util.add_day(datetime.now(), 1, -5)


print(d)
