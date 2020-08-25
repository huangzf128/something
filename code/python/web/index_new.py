import time, getResource, os


class FetchPic:

    def __init__(self):
        #self.driver = webdriver.Chrome()
        pass

    def get_img(self, img_urls, referers):
        getRes = getResource.GetResource("output/pic")
        for idx, url in enumerate(img_urls):
            getRes.get(url, referers[idx])

    def fetch(self, pageUrl, imgUrl, folderNum):

        img_urls = []
        referers = []
        pageUrl = pageUrl.replace("[folder]", folderNum)
        imgUrl = imgUrl.replace("[folder]", folderNum)
        # for i in range(5, 10):
        #     img_urls.append(url + str(i) + ".jpg")
        for i in range(1, 13):

            for j in range(1, 5):                
                img_urls.append(imgUrl.replace("[n]", str((i - 1) * 4 + j)))
                if (i == 1):
                    referers.append(pageUrl.replace("[n]", ""))
                else:
                    referers.append(pageUrl.replace("[n]", "_" + str(i)))                      
        self.get_img(img_urls, referers)


os.environ['PATH'] += ';F:\\repo\\something\\code\\python\\web;'
fetch_pic = FetchPic()
pageBase = "https://www.meitulu.cn/item/[folder][n].html"
imgBase = "https://mtl.ttsqgs.com/images/img/[folder]/[n].jpg"
folderNum = "13747"
fetch_pic.fetch(pageBase, imgBase, folderNum)
#fetch_pic.fetch("https://www.meitulu.com/item/10681_[n].html")
#fetch_pic.fetch("http://img.cct58.com/caiji/mm/201801/2802/20180128021022_[n].jpg")