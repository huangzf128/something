from datetime import datetime
from hzf.date import date_util

d = date_util.datetime_2_str(datetime.now(), date_util.FMT_YMD)
d = date_util.str_2_datetime(d, date_util.FMT_YMD)

# d = date_util.add_datetime(datetime.now(), day=1)
# d = date_util.add_month(datetime.now(), 1)

d = date_util.first_day_of_week(datetime.now())
d = date_util.last_day_of_week(datetime.now())
d = date_util.first_day_of_month(datetime.now())
d = date_util.last_day_of_month(datetime.now())


print(d)
