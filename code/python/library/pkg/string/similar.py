import difflib

def get_similar_rate(s1, s2):
    return difflib.SequenceMatcher(None, s1, s2).ratio()

def is_similar_name(s1, s2, similar_rate=1):

    rate = get_similar_rate(s1, s2)
    return rate >= similar_rate;

def has_similar_name(s1, l, similar_rate=1):

    for s in l:
        rate = get_similar_rate(s1, s)
        if rate >= similar_rate:
            return True
