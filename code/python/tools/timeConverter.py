import time

def sec2Min(sec):
    return time.strftime('%H:%M', time.gmtime(sec))

if (__name__ == "__main__"):
    print(sec2Min(4797641000000/1000000000))
