import difflib

def get_similar_rate(str1, str2):
    return difflib.SequenceMatcher(None, str1, str2).ratio()
