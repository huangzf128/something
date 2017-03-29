from urllib.parse import urlencode
from urllib.request import Request, urlopen

url = "http://local:18080/TrustEye/REST/ISC403"
#url = "http://10.83.240.20:18080/TrustEye/REST/ISC403"

post_fields = {'gateProcessDate': '2017/03/08 18:27:01',
               'computerName': '44',
               'idNo': '100',
               'idNoEda': '3',
               'crdTy': '1',
               'tmVld': '29991231',
               'cnty': 'JPN',
               'biko': 'ありがとう'
               #'bioData': 'null'
               }

request = Request(url, urlencode(post_fields).encode())
json = urlopen(request).read().decode()
print(json)
