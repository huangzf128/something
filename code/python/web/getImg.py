import urllib.request, re, os

class GetResource:
    def __init__(self, folder_path):
        self.f_path = folder_path
        if folder_path is not None and not os.path.exists(folder_path):
            os.makedirs(folder_path)

    def fetch(self, url):
        


        
img_url = r"https://scontent-nrt1-1.cdninstagram.com/t51.2885-15/e35/22159066_119431165390165_8354755686248218624_n.jpg"
matchObj = re.search(r'[^/]+?\.jpg$', img_url)
file_name = matchObj.group()

folder_name = "pic"


urllib.request.urlretrieve(img_url, folder_name + "/" + file_name)
