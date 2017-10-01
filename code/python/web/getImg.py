import urllib.request

img_url = r"https://scontent-nrt1-1.cdninstagram.com/t51.2885-15/e35/22159066_119431165390165_8354755686248218624_n.jpg"
folder_name = "id"
urllib.request.urlretrieve(img_url, "local-filename.jpg")
