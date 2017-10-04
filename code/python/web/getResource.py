import urllib.request, re, os

class GetResource:
    def __init__(self, folder_path):
        self.f_path = folder_path
        if folder_path is not None and not os.path.exists(folder_path):
            os.makedirs(folder_path)

    def get_path_tail(self, path):
        matchObj = re.search(r'[^/]+?$', path)
        return matchObj.group()

    def get(self, url):
        file_name = self.get_path_tail(url)
        urllib.request.urlretrieve(url, self.f_path + "/" + file_name)


if __name__ == '__main__':
    img_url = r"https://scontent-nrt1-1.cdninstagram.com/t51.2885-15/e35/22159066_119431165390165_8354755686248218624_n.jpg"
    folder_name = "pic"

    getRes = GetResource(folder_name)
    getRes.get(img_url)
