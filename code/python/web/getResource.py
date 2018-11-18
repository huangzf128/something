import urllib.request, re, os

class GetResource:
    def __init__(self, folder_path):
        self.f_path = folder_path
        if folder_path is not None and not os.path.exists(folder_path):
            os.makedirs(folder_path)

    def get_path_tail(self, path):
        matchObj = re.search(r'[^/]+?$', path)
        return matchObj.group()

    def get(self, url, referer):
        opener = urllib.request.build_opener()
        opener.addheaders = [#('authority', 'mtl.ttsqgs.com'), ('method', 'GET'), ('path', path), 
                              #  ('scheme', 'https'), ("cache-control", "1"),
                              #  ("if-modified-since", 'Sun, 02 Jul 2019 12:40:22 GMT'),
                              #  ("upgrade-insecure-requests", "1"),
                                ("referer", referer),
                                ('user-agent', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.67 Safari/537.36')]
        # opener.addheaders = [   ("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8"),
        #                         ("Accept-Encoding", "gzip, deflate, br"),
        #                         ("Accept-Language", "ja,en-US;q=0.9,en;q=0.8,zh-CN;q=0.7,zh;q=0.6"),
        #                         ("cache-control", "0"),
        #                         ("Host", "www.meitulu.com"),
        #                         ("if-modified-since", 'Wed, 19 Sep 2018 11:54:38 GMT'),
        #                         ("If-None-Match", '3a2f-576381223662f-gzip'),
        #                         ("upgrade-insecure-requests", "1"),
        #                         ("Cookie", "ggy_second=true; UM_distinctid=166fbbe75711c6-0c7aabaea7f356-b79193d-144000-166fbbe757467; __tins__3892343=%7B%22sid%22%3A%201541821919520%2C%20%22vd%22%3A%201%2C%20%22expires%22%3A%201541823719520%7D; __51cke__=; __51laig__=1; Hm_lvt_60852cb607c7b21f13202e5e672131ce=1541821925,1541822006; Hm_lvt_6fb6bee8deeec3134fac140e50fed47a=1541821865,1541822006,1541822026; CNZZDATA1255487232=1210176341-1541831383-%7C1541831383; Hm_lpvt_6fb6bee8deeec3134fac140e50fed47a=1541859959; CNZZDATA1255357127=914658678-1541818081-null%7C1541857507; Hm_lpvt_60852cb607c7b21f13202e5e672131ce=1541859960"),
        #                         ('user-agent', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.67 Safari/537.36')]
        urllib.request.install_opener(opener)

        file_name = self.get_path_tail(url)
        try:
            urllib.request.urlretrieve(url, self.f_path + "/" + file_name)
        except:
            pass


if __name__ == '__main__':
    img_url = r"https://scontent-nrt1-1.cdninstagram.com/t51.2885-15/e35/22159066_119431165390165_8354755686248218624_n.jpg"
    folder_name = "pic"

    getRes = GetResource(folder_name)
    getRes.get(img_url)
